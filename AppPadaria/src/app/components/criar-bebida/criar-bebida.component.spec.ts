import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarBebidaComponent } from './criar-bebida.component';

describe('CriarBebidaComponent', () => {
  let component: CriarBebidaComponent;
  let fixture: ComponentFixture<CriarBebidaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CriarBebidaComponent]
    });
    fixture = TestBed.createComponent(CriarBebidaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
