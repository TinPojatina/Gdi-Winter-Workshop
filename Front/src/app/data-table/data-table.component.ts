import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { Data } from 'src/Shared/Models/IData'
import { environment } from 'src/environments/environment';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss']
})



export class DataTableComponent implements OnInit {
  displayedColumns = ['id', 'returnedValue', 'sensorId']
  tableData: Data[] = [];
  dataSource = new MatTableDataSource<Data>(this.tableData);
  constructor(private http: HttpClient) { }


  ngOnInit() {
    this.http.get<Data[]>(`${environment.apiEndpoint}PaginatedTable/1/15`).subscribe(data => {
      this.tableData = data;
      console.log(this.tableData);
    });
  }
}
