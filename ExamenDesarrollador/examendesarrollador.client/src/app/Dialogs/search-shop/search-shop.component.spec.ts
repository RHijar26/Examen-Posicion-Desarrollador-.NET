import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchShopComponent } from './search-shop.component';

describe('SearchShopComponent', () => {
  let component: SearchShopComponent;
  let fixture: ComponentFixture<SearchShopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SearchShopComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
