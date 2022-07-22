import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule} from '@angular/common/http/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { RegisterComponent } from './register.component';

describe('RegisterComponent', () => {
  let component: RegisterComponent;
  let fixture: ComponentFixture<RegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterComponent ],
      imports:[HttpClientTestingModule, RouterTestingModule, ReactiveFormsModule, FormsModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('User Name is required and it should not be empty validation', () => {
    let user = component.registerModel.formCustomerGroup.controls['LoginControl'];
    expect(user.valid).toBeFalsy();
  });

  it('Password is required and it should not be empty validation', () => {
    let password = component.registerModel.formCustomerGroup.controls['PasswordControl'];
    expect(password.valid).toBeFalsy();
  });

  it('User Name is not empty and it is valid', () => {
    let user = component.registerModel.formCustomerGroup.controls['LoginControl'];
    user.setValue("rathi@test.com");
    expect(user.valid).toBeTruthy();
  });
  
  it('Password is not empty and it is valid', () => {
    let password = component.registerModel.formCustomerGroup.controls['PasswordControl'];
    password.setValue("rathi");
    expect(password.valid).toBeTruthy();
  });

  it('User Name and Password is not empty and it is valid', () => {
    component.registerModel.formCustomerGroup.controls['LoginControl'].setValue("rathi@test.com");
    component.registerModel.formCustomerGroup.controls['PasswordControl'].setValue("rathi");
    component.Register()
    expect(component.registerModel.formCustomerGroup.valid).toBeTruthy();
  });

});
