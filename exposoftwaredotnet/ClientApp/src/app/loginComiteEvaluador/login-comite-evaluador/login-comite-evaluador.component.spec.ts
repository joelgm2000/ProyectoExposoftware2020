import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginComiteEvaluadorComponent } from './login-comite-evaluador.component';

describe('LoginComiteEvaluadorComponent', () => {
  let component: LoginComiteEvaluadorComponent;
  let fixture: ComponentFixture<LoginComiteEvaluadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginComiteEvaluadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComiteEvaluadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
