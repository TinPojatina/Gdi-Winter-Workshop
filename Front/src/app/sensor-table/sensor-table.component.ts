import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';
// import {MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Sensor } from 'src/Shared/Models/ISensor';
import { environment } from 'src/environments/environment';
@Component({
  selector: 'app-sensor-table',
  templateUrl: './sensor-table.component.html',
  styleUrls: ['./sensor-table.component.scss'],
})



export class SensorTableComponent implements OnInit {
  displayedColumns = ['id', 'name', 'sensorSerial', 'button', 'edit/delete']
  tableData: Sensor[] = [];
  dataSource = new MatTableDataSource<Sensor>(this.tableData);

  constructor(private http: HttpClient) { }


  ngOnInit() {
    this.http.get<Sensor[]>(`${environment.apiEndpoint}Get-Sensors`).subscribe(data => {
      this.tableData = data;
      this.tableData.forEach((el) => console.log(typeof(el)))
    });
  }

  checkSensorStatus(id: number){
   this.http.post<any>(`${environment.apiEndpoint}api/SignalRealTime/SensorCheck/${id}`, id).subscribe();
  }

  
  onDelete(id:any){
    if(window.confirm("Are you sure you want to delete sensor?")){
      this.http.delete<Sensor>(`${environment.apiEndpoint}Remove-Sensor/${id}`).subscribe(Response);
      console.log(Response);
    }
    else{
      window.close();
    }
  }
  onEdit(id:any){
    console.log("Pretend I'm an edit box.")
  }
  createNewSensorType(){
    console.log("Whooooo");
  }
}

