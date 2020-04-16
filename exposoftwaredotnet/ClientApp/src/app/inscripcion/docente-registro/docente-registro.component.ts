import { Component, OnInit } from '@angular/core';
import { Docente } from '../models/docente';
import { DocenteService } from '../../services/docente.service';

@Component({
  selector: 'app-docente-registro',
  templateUrl: './docente-registro.component.html',
  styleUrls: ['./docente-registro.component.css']
})
export class DocenteRegistroComponent implements OnInit {

  docente: Docente;
  constructor(private docenteService: DocenteService) { }

  ngOnInit(): void {
    this.docente = new Docente();
  }
  add(){
    this.docenteService.post(this.docente).subscribe(d => {
      if(d != null){
        alert('Docente registrado');
        this.docente = d;
      }
    });
  }

}
