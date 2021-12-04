import { Component, Input, OnInit } from '@angular/core';
import { Files } from 'src/app/Services/Estructura/files';
import { FileService } from '../../Services/Rest/FileService';

@Component({
  selector: 'app-file',
  templateUrl: './file.component.html',
  styleUrls: ['./file.component.scss']
})
export class FileComponent implements OnInit {
  @Input() archivo: Files = new Files();

  constructor(private fileService: FileService) { }

  ngOnInit(): void {
  }

  //#region carga archivos
  fileDownload: any = '';
  cargaImagen(baseId: string) {
    this.fileService.getShortFiles(baseId).subscribe((response: any) => {
      this.fileDownload = response;
      console.log(response);
    }, (error: any) => {
      console.log(error);
    });
  }

  cargaVideo(baseId: string) {

  }

  cargaText(baseId: string) {

  }
  //#endregion

  oculto: boolean = false;
  menuOpciones(data: Files, evento: any) {
    evento.preventDefault();
    this.oculto = true;
    console.table(data);
    console.table(evento)
  }


}
