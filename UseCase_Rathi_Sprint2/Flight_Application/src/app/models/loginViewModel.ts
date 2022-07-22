import { NgForm,FormGroup,Validators,FormBuilder,FormControl } from "@angular/forms";

export class loginViewModel{
    userName:string='';
    password:string='';
    role:string='';
    formCustomerGroup:FormGroup;//Create
    constructor() {
        var validationcollection = [];
        validationcollection.push(Validators.required);
        validationcollection.push(Validators.pattern("[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$"))
        var _builder=new FormBuilder();
       this.formCustomerGroup=_builder.group({});
       this.formCustomerGroup.addControl("LoginControl",new FormControl('',Validators.compose(validationcollection)));
       this.formCustomerGroup.addControl("PasswordControl",new FormControl('',Validators.required));
    }
}

