import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalgadosComponent } from './salgados.component';

describe('SalgadosComponent', () => {
  let component: SalgadosComponent;
  let fixture: ComponentFixture<SalgadosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SalgadosComponent]
    });
    fixture = TestBed.createComponent(SalgadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
