//pokretanje: node ExternalTaskWorker.js
import { Client, logger, Variables } from "camunda-external-task-client-js";
 
import fetch from "node-fetch";
 
import https from 'https';
 
 
const config = { baseUrl: "http://localhost:8080/engine-rest", use: logger };
 
const client = new Client(config);
 
 
const apiUrl = `https://localhost:7178/api/SignalRealTime/api/sensors/check`;
const apiUrlNotifications = `https://localhost:7178/api/SignalRealTime/api/sensors/notify`
 
 
client.subscribe("statusValidation", async function( {task, taskService})  {
 
 
    console.log("Got to sensor status");
 
 
    //httpGET
 
 
    //disable SSL verification which API requires
 
    const httpsAgent = new https.Agent({
 
        rejectUnauthorized: false,
 
    });
 
 
    let url = apiUrl;
 
    console.log(url);
 
 
    fetch(url, {
 
        method: 'GET',
 
        agent: httpsAgent,
 
      })
 
      .then( async (success) => 
 
      {
 
        console.log("Success sensor status");
 
        let isWorking = await success.text();
 
        console.log("sensorvalid" + isWorking);
 
 
        const processVariables = new Variables()
 
            .set("sensorvalid", isWorking);
 
 
        // complete the task
 
        try {
 
            await taskService.complete(task, processVariables);
 
            console.log("I completed my task successfully!!");
 
        } catch (e) {
 
            console.error(`Failed completing my task, ${e}`);
 
        }
 
      })
 
      .catch(err => console.log( "Error while fetching " + err));
 
    
 
});
 
 
client.subscribe("forwardNotification", async function( {task, taskService})  {
 
    //httpPOSTNotify + id + alert
 
    let url = `${apiUrlNotifications}/notify`;
 
 
    let header = new Headers();
 
    header.set("Content-Type", "application/json");
 
 
    let id = task.businessKey;
 
    let message = "Alert! Sensor with the serial number " + id + " is not functional. Please check the sensor";
 
 
    console.log("Message "+ message);
 
 
    //disable SSL verification which API requires
 
    const httpsAgent = new https.Agent({
 
        rejectUnauthorized: false,
 
    });
 
 
    let params = { method: 'POST', body: JSON.stringify( { "id": id, "message": message  } ), headers: header, agent: httpsAgent};
 
 
    fetch(url, params)
 
    .then( async (success) => 
 
    {
 
        console.log("Success send alert");
 
        let alertSent = await success.text();
 
        console.log("Alert sent: " + alertSent);
 
        // complete the task
 
        try {
 
            await taskService.complete(task);
 
            console.log("I completed my task successfully!!");
 
        } catch (e) {
 
            console.error(`Failed completing my task, ${e}`);
 
        }
 
    })
 
    .catch(err => console.log( "Error while fetching " + err));
 
    
 
});
