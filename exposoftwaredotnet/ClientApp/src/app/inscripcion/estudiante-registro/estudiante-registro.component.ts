import { Component, OnInit } from '@angular/core';
import { Estudiante } from '../models/estudiante';
import { EstudianteService } from '../../services/estudiante.service';

@Component({
  selector: 'app-estudiante-registro',
  templateUrl: './estudiante-registro.component.html',
  styleUrls: ['./estudiante-registro.component.css']
})
export class EstudianteRegistroComponent implements OnInit {

  estudiante: Estudiante;
  constructor(private estudianteService: EstudianteService) { }

  ngOnInit(): void {
    this.estudiante = new Estudiante();
  }
  
  add(){
    this.estudianteService.post(this.estudiante).subscribe(e => {
      if(e != null){
        alert('Estudiante registrado');
        this.estudiante = e;
      }
    });
  }

}
