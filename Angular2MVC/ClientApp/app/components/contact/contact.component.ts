import { Component, OnInit, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { elementAt } from 'rxjs/operator/elementAt';
//import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule } from 'primeng/primeng';

@Component({
    selector: 'contact',
    templateUrl: './contact.component.html',
})
export class ContactComponent implements OnInit {

    public listContact: Contact[];
    public contact: Contact;
    isDisplayAddEditDialog: boolean;
    isDisplayDeleteDialog: boolean;
    public isNewContact: boolean;
    public editContactId: any;
    public fullname: string;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    ngOnInit() {
        this.editContactId = 0;
        this.loadData();
    }

    loadData() {
        this.http.get(this.baseUrl + 'Contact/GetContacts').subscribe(result => {
            this.listContact = <any>(<Response>result).json().result;
        }, error => console.error(error));
    }

    showDialogToAdd() {
        this.isNewContact = true;
        this.editContactId = 0;
        this.contact = new Contact();
        this.isDisplayAddEditDialog = true;
    }

    showDialogToEdit(contact: Contact) {
        this.isNewContact = false;
        this.contact = {
            contactId: contact.contactId,
            firstName: contact.firstName,
            lastName: contact.lastName,
            email: contact.email,
            phone: contact.phone
        };
        this.isDisplayAddEditDialog = true;
    }

    onRowSelect(event: any) {
    }

    okSave() {
        let body = JSON.stringify(this.contact);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        this.http.post(this.baseUrl + 'Contact/SaveContact', body, options).subscribe(result => {
            if (result.json()) {
                if (this.isNewContact) {
                    alert("Add successfully");
                } else {
                    alert("Edit successfully");
                }
                this.loadData();
            }
        }, error => console.error(error));
        this.isDisplayAddEditDialog = false;
    }

    cancelSave() {
        this.contact = new Contact();
        this.isDisplayAddEditDialog = false;
    }

    showDialogToDelete(contact: Contact) {
        this.fullname = contact.firstName + ' ' + contact.lastName;
        this.editContactId = contact.contactId;
        this.isDisplayDeleteDialog = true;
    }

    okDelete(isDeleteConfirm: boolean) {
        if (isDeleteConfirm) {
            this.http.delete(this.baseUrl + 'Contact/DeleteContactByID/' + this.editContactId).subscribe(result => {
                if (result.json()) {
                    alert("Delete successfully");
                    this.loadData();
                }
            }, error => console.error(error));
        }
        this.isDisplayDeleteDialog = false;
    }
}

class Contact {
    public contactId: any;
    public firstName: any;
    public lastName: any;
    public email: any;
    public phone: any;
}