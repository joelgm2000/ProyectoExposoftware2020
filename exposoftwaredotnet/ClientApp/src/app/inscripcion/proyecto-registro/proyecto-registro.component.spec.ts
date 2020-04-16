import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProyectoRegistroComponent } from './proyecto-registro.component';

describe('ProyectoRegistroComponent', () => {
  let component: ProyectoRegistroComponent;
  let fixture: ComponentFixture<ProyectoRegistroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProyectoRegistroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProyectoRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
