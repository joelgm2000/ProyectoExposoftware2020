import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginLiderProyectoComponent } from './login-lider-proyecto.component';

describe('LoginLiderProyectoComponent', () => {
  let component: LoginLiderProyectoComponent;
  let fixture: ComponentFixture<LoginLiderProyectoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginLiderProyectoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginLiderProyectoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
