import { Component, OnInit } from '@angular/core';
import { FileService } from '../../Services/Rest/FileService';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-view-file',
  templateUrl: './view-file.component.html',
  styleUrls: ['./view-file.component.scss']
})
export class ViewFileComponent implements OnInit {
  fileBaseId: string = "";
  controlCodigo: boolean = false; //Permite controlar si la consulta de ese archivo tiene el baseId diferente de vacio
  constructor(private fileService: FileService, private route: ActivatedRoute) {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let parametro = params.get('baseId');
      this.fileBaseId = parametro != null && parametro != undefined ? parametro : "";
    });
  }

  ngOnInit(): void {
    this.cargaArchivo(this.fileBaseId);
  }

  cargaArchivo(fileBaseId: string) {
    if (fileBaseId != "") {
      this.controlCodigo = true;

    }
  }
}
