import { Observable } from 'rxjs';
import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { GridComponent, GridDataResult, CancelEvent, EditEvent, RemoveEvent, SaveEvent, AddEvent } from '@progress/kendo-angular-grid';
import { State, process } from '@progress/kendo-data-query';
import { Client } from './model';
import { EditService } from './edit.service';
import { map } from 'rxjs/operators';

@Component({
    selector: 'my-app',
    template: `
        <kendo-grid
            [filterable]="true"
            [data]="view | async"
            [pageSize]="gridState.take"
            [skip]="gridState.skip"
            [sort]="gridState.sort"
            [pageable]="true"
            [sortable]="true"
            (dataStateChange)="onStateChange($event)"
            (edit)="editHandler($event)"
            (cancel)="cancelHandler($event)"
            (save)="saveHandler($event)"
            (remove)="removeHandler($event)"
            (add)="addHandler($event)"
            [navigable]="true"
        >
            <ng-template kendoGridToolbarTemplate>
                <button kendoGridAddCommand>Add new Client</button>
            </ng-template>
            <kendo-grid-column field="id" title="Client Id"></kendo-grid-column>
            <kendo-grid-column  [filterable]="true" field="name" title="Name"></kendo-grid-column>
            <kendo-grid-column  [filterable]="true"field="emailAddress"  title="EmailAddress"></kendo-grid-column>
            <kendo-grid-column  [filterable]="true"field="country" title="Country"></kendo-grid-column>
            <kendo-grid-column  [filterable]="true"  filter="boolean" field="isUpdated"  title="Is Updated"></kendo-grid-column>
            <kendo-grid-column  [filterable]="true" filter= "date"  format= "d" field="lastupdated"  title="Last Updated"></kendo-grid-column>
            <kendo-grid-command-column title="Actions" [width]="220">
                <ng-template kendoGridCellTemplate let-isNew="isNew">
                    <button kendoGridEditCommand [primary]="true">Edit</button>
                    <button kendoGridRemoveCommand>Remove</button>
                    <button kendoGridSaveCommand [disabled]="formGroup?.invalid">{{ isNew ? 'Add' : 'Update' }}</button>
                    <button kendoGridCancelCommand>{{ isNew ? 'Discard changes' : 'Cancel' }}</button>
                </ng-template>
            </kendo-grid-command-column>
        </kendo-grid>
    `
})
export class AppComponent implements OnInit {
    public view: Observable<GridDataResult> | undefined;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 5
    };
    public formGroup: FormGroup;

    private editService: EditService;
    private editedRowIndex: number;

    constructor(@Inject(EditService) editServiceFactory: () => EditService) {
        this.editService = editServiceFactory();
    }

    public ngOnInit(): void {
        this.view = this.editService.pipe(map((data) => process(data, this.gridState)));
     
        this.editService.read();
    }

    public onStateChange(state: State): void {
        this.gridState = state;

        this.editService.read();
    }

    public addHandler(args: AddEvent): void {
        this.closeEditor(args.sender);
        this.formGroup = new FormGroup({
            name: new FormControl('', Validators.compose([Validators.required])),
            emailAddress    : new FormControl('',Validators.compose([Validators.required])),
            country: new FormControl('',Validators.compose([Validators.required])),
            isUpdated: new FormControl('',),
            lastupdated: new FormControl('',),
          
        });
        args.sender.addRow(this.formGroup);
    }

    public editHandler(args: EditEvent): void {
        
        const { dataItem } = args;  
        this.closeEditor(args.sender);

        this.formGroup = new FormGroup({
            id: new FormControl(dataItem.id),
            name: new FormControl(dataItem.name, Validators.compose([Validators.required])),
            emailAddress    : new FormControl(dataItem.emailAddress,Validators.compose([Validators.required])),
            country: new FormControl(dataItem.country,Validators.compose([Validators.required])),
            isUpdated: new FormControl(dataItem.isUpdated,),
            lastupdated: new FormControl(dataItem.lastupdated,),

          
        });

        this.editedRowIndex = args.rowIndex;
        args.sender.editRow(args.rowIndex, this.formGroup);
    }

    public cancelHandler(args: CancelEvent): void {
        this.closeEditor(args.sender, args.rowIndex);
    }

    public saveHandler({sender, rowIndex, formGroup, isNew}: SaveEvent): void {
        const product: Client[] = formGroup.value;

        this.editService.save(product, isNew);

        sender.closeRow(rowIndex);
    }

    public removeHandler(args: RemoveEvent): void {
      
        this.editService.remove(args.dataItem);
    }

    private closeEditor(grid: GridComponent, rowIndex = this.editedRowIndex) {
        // close the editor
        grid.closeRow(rowIndex);
        // reset the helpers
        this.editedRowIndex = undefined;
        this.formGroup = undefined;
    }
}