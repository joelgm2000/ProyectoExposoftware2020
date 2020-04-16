import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { DocenteRegistroComponent } from './inscripcion/docente-registro/docente-registro.component';
import { EstudianteRegistroComponent } from './inscripcion/estudiante-registro/estudiante-registro.component';
import { ProyectoRegistroComponent } from './inscripcion/proyecto-registro/proyecto-registro.component';
import { LoginLiderProyectoComponent } from './loginLiderProyecto/login-lider-proyecto/login-lider-proyecto.component';
import { LoginDocenteEvaluadorComponent } from './loginDocenteEvaluador/login-docente-evaluador/login-docente-evaluador.component';
import { LoginComiteEvaluadorComponent } from './loginComiteEvaluador/login-comite-evaluador/login-comite-evaluador.component';
import { InformacionComponent } from './informacion/informacion/informacion.component';

const routes: Routes = [
  {
    path: 'proyectoRegistro',
    component: ProyectoRegistroComponent
    },
    {
      path: 'docenteRegistro',
      component: DocenteRegistroComponent
    },
    {
      path: 'estudianteRegistro',
      component: EstudianteRegistroComponent
    },
  {
    path: 'loginLider',
    component: LoginLiderProyectoComponent

  },

  {
    path: 'LoginDocenteEvaluador',
    component: LoginDocenteEvaluadorComponent

  },

  {
    path: 'LoginComiteEvaluador',
    component: LoginComiteEvaluadorComponent

  },
  
  {
    path: 'Informacion',
    component: InformacionComponent

  },

  {
    path: 'docenteRegistro',
    component: DocenteRegistroComponent
  },
  {
    path: 'estudianteRegistro',
    component: EstudianteRegistroComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
})
export class AppRoutingModule { }
