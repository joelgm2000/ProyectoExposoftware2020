import { Component, OnInit } from '@angular/core';
import { Proyecto } from '../models/proyecto';
import { ProyectoService } from '../../services/proyecto.service';

@Component({
  selector: 'app-proyecto-registro',
  templateUrl: './proyecto-registro.component.html',
  styleUrls: ['./proyecto-registro.component.css']
})
export class ProyectoRegistroComponent implements OnInit {

  proyecto: Proyecto;
  constructor(private proyectoService: ProyectoService) { }

  ngOnInit(): void {
    this.proyecto = new Proyecto();
  }
  add(){
    this.proyectoService.post(this.proyecto).subscribe(p => {
      if(p != null){
        alert('Proyecto Registrado');
        this.proyecto = p;
      }
    });
  }

}
