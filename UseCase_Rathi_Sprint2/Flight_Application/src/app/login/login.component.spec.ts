import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LoginComponent } from './login.component';
import { HttpClientTestingModule} from '@angular/common/http/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginComponent ],
      imports:[HttpClientTestingModule, RouterTestingModule, ReactiveFormsModule, FormsModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('User Name is required and it should not be empty validation', () => {
    let user = component.loginModel.formCustomerGroup.controls['LoginControl'];
    expect(user.valid).toBeFalsy();
  });

  it('Password is required and it should not be empty validation', () => {
    let password = component.loginModel.formCustomerGroup.controls['PasswordControl'];
    expect(password.valid).toBeFalsy();
  });

  it('User Name is not empty and it is valid', () => {
    let user = component.loginModel.formCustomerGroup.controls['LoginControl'];
    user.setValue("rathi@test.com");
    expect(user.valid).toBeTruthy();
  });
  
  it('Password is not empty and it is valid', () => {
    let password = component.loginModel.formCustomerGroup.controls['PasswordControl'];
    password.setValue("rathi");
    expect(password.valid).toBeTruthy();
  });

  it('User Name and Password is not empty and it is valid', () => {
    component.loginModel.formCustomerGroup.controls['LoginControl'].setValue("rathi@test.com");
    component.loginModel.formCustomerGroup.controls['PasswordControl'].setValue("rathi");
    component.Login()
    expect(component.loginModel.formCustomerGroup.valid).toBeTruthy();
    expect(component.loginModel.userName).toBe("rathi@test.com");
    expect(component.loginModel.password).toBe("rathi");
  });

});
