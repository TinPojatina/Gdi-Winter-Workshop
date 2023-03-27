import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
import { SensorType } from 'src/Shared/Models/ISensorType'
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-type-table',
  templateUrl: './type-table.component.html',
  styleUrls: ['./type-table.component.scss']
})
export class TypeTableComponent implements OnInit {
  displayedColumns = ['name', 'edit/delete']
  tableData: SensorType[] = [];
  dataSource = new MatTableDataSource<SensorType>(this.tableData);
  constructor(private http: HttpClient) { }


  ngOnInit() {
    this.http.get<SensorType[]>(`${environment.apiEndpoint}Get-Sensor-Types`).subscribe(data => {
      console.log(data);
      this.tableData = data;
      this.tableData.forEach((el) => console.log(typeof(el)));
    });
  }

  onDelete(id:any){
    if(window.confirm("Are you sure you want to delete this type?")){
      this.http.delete<SensorType>(`${environment.apiEndpoint}Remove-Sensor-Type/${id}`).subscribe(Response);
      console.log(Response);
    }
    else{
    }
  }
  onEdit(id:any){
    console.log("Pretend I'm an edit box.")
  }
  createNewSensorType(){
    console.log("Whooooo");
  }
}
