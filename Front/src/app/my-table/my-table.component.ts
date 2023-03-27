import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { Data } from '../data.interface'


@Component({
  selector: 'app-my-table',
  templateUrl: './my-table.component.html',
  styleUrls: ['./my-table.component.scss']
})



export class MyTableComponent implements OnInit {
  displayedColumns = ['id', 'returnedValue', 'sensorSerial']
  tableData: Data[] = [{ id: 1, returnedValue:  2,sensorSerial: 3}];
  dataSource = new MatTableDataSource<Data>(this.tableData);
  constructor(private http: HttpClient) { }


  ngOnInit() {
    // this.http.get<Data[]>('').subscribe(data => {

    // });
  }
}
