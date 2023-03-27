import { Component } from '@angular/core';
import { SocketService } from 'src/Shared/Sockets/socket.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Practice';

  constructor(private socketService: SocketService){
    
  }

  ngOnInit(): void{
    this.socketService.buildConnection();
  }
}
