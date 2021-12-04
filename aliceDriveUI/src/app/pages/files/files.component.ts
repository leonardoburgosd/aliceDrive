import { ActivatedRoute, ParamMap } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FileService } from '../../Services/Rest/FileService';
import { Files } from '../../Services/Estructura/files';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.scss']
})
export class FilesComponent implements OnInit {
  private carpeta: string = "";//codigo de la carpeta abierta
  particiones: Boolean = false; //verifica si esta consultando dentro de un disco duro

  constructor(
    private route: ActivatedRoute,
    private fileService: FileService) {
    this.capturaDatosUrl();
  }

  //#region Primera carga de datos
  capturaDatosUrl() {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let parametro = params.get('baseId');
      this.carpeta = parametro != null && parametro != undefined ? parametro : "";
      if (this.carpeta != "") this.particiones = true;
      this.muestraArchivos(this.carpeta);
    });
  }

  listaArchivos: Files[] = [];
  muestraArchivos(carpeta: string) {
    if (carpeta == '')
      this.listarArchivosRoot();
    else
      this.listarArchivosHijos(carpeta);
  }

  listarArchivosRoot() {
    this.fileService.getDisk().subscribe((response: Files[]) => { this.listaArchivos = response; },
      (error: any) => {
        console.log(error);
      });
  }

  listarArchivosHijos(carpeta: string) {
    this.fileService.getChildren(carpeta).subscribe((response: Files[]) => { this.listaArchivos = response; },
      (error: any) => {
        console.log(error);
      });
  }
  //#endregion

  ngOnInit(): void {

  }

  //#region Crear carpetas y registrar particiones de disco
  nuevaCarpeta: Files = new Files();
  agregarCarpeta() {
    if (this.carpeta == '') {
      this.fileService.createDisk(this.nuevaCarpeta).subscribe((resp: any) => { this.muestraArchivos(this.carpeta); },
        (error: any) => {
          console.log(error);
        });
    } else {
      this.fileService.createArchive(this.nuevaCarpeta, this.carpeta).subscribe((response: any) => { this.muestraArchivos(this.carpeta); },
        (error: any) => {
          console.log(error);
        }
      );
    }
    this.nuevaCarpeta = new Files();
  }
  //#endregion

  //#region Sube archivos
  async agregarArchivo() {
    if (this.carpeta == '') this.cargaErrores("No se puede agregar archivo en esta posicion."); // alertar: no se puede crear carpetas en el root
    else {
      let response: String[] = [];
      for (let i = 0; i < this.cantidadArchivosSubir; i++) {
        response.push(await this.fileService.upload(this.archivosSeleccionados[i], this.carpeta));
      }
      this.listarArchivosHijos(this.carpeta);
    }
  }

  cantidadArchivosSubir: number = 0;//numero de carchivos seleccionados para subir
  archivosSeleccionados: File[] = [];//archivos seleccionados para subir
  capturaArchivosLocalmente(event: any) {
    this.cantidadArchivosSubir = event.target.files.length;
    this.archivosSeleccionados = event.target.files;
  }
  //#endregion

  //#region Descargar archivo
  descargarArchivo(fileIdSeleccionado: string) {
    this.fileService.getShortFiles(fileIdSeleccionado).subscribe(
      (resp: any) => {
        this.convertirBase64aArchivo(resp.type, resp.file, resp.name);
      },
      (error: any) => this.cargaErrores(error)
    );
    this.ocultarMenu();
  }

  //#endregion

  //#region Metodos complementarios

  private convertirBase64aArchivo(tipo: string, archivo: string, nombre: string) {
    const linkSource = 'data:' + tipo + ';base64,' + archivo;
    const download = document.createElement("a");
    download.href = linkSource;
    download.download = nombre;
    download.click();
  }

  cargaErrores(mensaje: string) {
    Swal.fire({
      icon: 'error',
      title: 'Oops...',
      text: mensaje,
    })
  }

  oculto: boolean = false;
  posicionX: number = 0;
  posicionY: number = 0;
  fileIdSeleccionado: string = "";

  menuOpciones(data: Files, evento: any) {
    evento.preventDefault();
    this.posicionX = evento.clientX;
    this.posicionY = evento.clientY;
    this.fileIdSeleccionado = data.fileBase;
    this.oculto = true;
  }

  ocultarMenu() {
    this.oculto = false;
  }

  detenerPropagacion(evento: any) {
    evento.stopPropagation();
    this.ocultarMenu();
  }

  //#endregion

}
