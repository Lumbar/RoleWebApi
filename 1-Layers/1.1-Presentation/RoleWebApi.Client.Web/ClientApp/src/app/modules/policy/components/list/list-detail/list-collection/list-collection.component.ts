import { Component, OnInit, ViewChild, ElementRef, Input, Output, EventEmitter, SimpleChanges, HostListener } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatDialog } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';
import ResizeObserver from 'resize-observer-polyfill';
import { Overlay } from '@angular/cdk/overlay';
import { ClientListCollectionViewModel, ClientListPaginationViewModel, ClientListDetailViewModel } from '../../../../viewmodels/index';

@Component({
  selector: 'pol-policy-list-collection',
  templateUrl: './list-collection.component.html',
  styleUrls: ['./list-collection.component.scss']
})
export class PolicyListCollectionComponent implements OnInit {

  @Input() ClientListCollectionsVM: ClientListCollectionViewModel[];
  @Input() ClientListPaginationVM: ClientListPaginationViewModel;
  @Input() ClientListDetailVM: ClientListDetailViewModel;

  @Output() paginateTable = new EventEmitter();
  @Output() visualize = new EventEmitter<ClientListCollectionViewModel>();

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild("tableComponent") tableComponent: ElementRef;

  public displayedColumns = ['edit', 'id', 'name', 'email', 'role'];

  public dataSource: MatTableDataSource<ClientListCollectionViewModel>;

  constructor() { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    this.dataSource = new MatTableDataSource<ClientListCollectionViewModel>(this.ClientListCollectionsVM);
    this.paginator.pageIndex = this.ClientListPaginationVM.PageIndex;
    this.updatePaginator(this.ClientListPaginationVM.TotalCount);

    this.resizeObserver();
    this.assignWidth();
  }

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.assignWidth();
  }

  resizeObserver() {
    var collectionListBody = this.tableComponent.nativeElement.ownerDocument.querySelector(".collection-list-body");
    var ro = new ResizeObserver((entries, observer) => {
      for (const entry of entries) {
        this.assignScroll(entry.target)
      }
    });

    ro.observe(collectionListBody);
  }

  assignScroll(collectionListBody: any) {
    var listHeaderPad = this.tableComponent.nativeElement.ownerDocument.querySelector(".list-header-pad");
    var scrollWidth = (collectionListBody.offsetWidth - collectionListBody.scrollWidth);
    if (listHeaderPad) {
      listHeaderPad.style.width = scrollWidth + "px";
      this.assignWidth();
    }
  }

  assignWidth() {

    var listCellHeader = this.tableComponent.nativeElement.ownerDocument.querySelectorAll(".list-header-component");
    var listCellColumnHeader = this.tableComponent.nativeElement.querySelectorAll(".list-column-header-component");
    var listCellColumn = this.tableComponent.nativeElement.querySelectorAll(".list-column-component");

    for (var i = 0; i < listCellColumnHeader.length; i++) {

      var k = i;
      var diferencia = (i == 0 || i == listCellColumnHeader.length - 1) ? 10 : 20;

      if (i > 0) {
        listCellColumnHeader[i].style.paddingLeft = "10px";
      }

      if (i < listCellColumnHeader.length - 1) {
        listCellColumnHeader[i].style.paddingRight = "10px";
      }

      listCellColumnHeader[i].style.width = (listCellHeader[i].getBoundingClientRect().width - diferencia) + "px";

      for (var j = 0; j < this.ClientListCollectionsVM.length; j++) {

        if (i > 0) {
          if (listCellColumn[k]) {
            listCellColumn[k].style.paddingLeft = "10px";
          }
        }

        if (i < listCellColumnHeader.length - 1) {
          if (listCellColumn[k]) {
            listCellColumn[k].style.paddingRight = "10px";
          }
        }

        if (listCellColumn[k]) {
          listCellColumn[k].style.width = (listCellHeader[i].getBoundingClientRect().width - diferencia) + "px";
        }

        k = k + listCellColumnHeader.length;

      }
    }
  }

  updatePaginator(filteredDataLength: number) {
    Promise.resolve().then(() => {
      if (!this.paginator) { return; }

      this.paginator.length = filteredDataLength;

      // If the page index is set beyond the page, reduce it to the last page. 
      if (this.paginator.pageIndex > 0) {
        const lastPageIndex = Math.ceil(this.paginator.length / this.paginator.pageSize) - 1 || 0;
        this.paginator.pageIndex = Math.min(this.paginator.pageIndex, lastPageIndex);
      }
    });
  }

  updatePaginatorValues(event: any) {
    this.ClientListPaginationVM.PageIndex = this.paginator.pageIndex;
    this.ClientListPaginationVM.PageSize = this.paginator.pageSize;

    this.paginateTable.emit();
  }
}
