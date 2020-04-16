import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginDocenteEvaluadorComponent } from './login-docente-evaluador.component';

describe('LoginDocenteEvaluadorComponent', () => {
  let component: LoginDocenteEvaluadorComponent;
  let fixture: ComponentFixture<LoginDocenteEvaluadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginDocenteEvaluadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginDocenteEvaluadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
