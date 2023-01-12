# Microservices using .Net Core

In this repo we have create simple microservice environment with 2 service that are
responsible for storing cli or scirpt commands for different platform. This system can 
be used by a support team to keep track of all platforms that they support and how to 
solve different tasks.

Using the following tech stack:

- .Net Core 
- RabbitMQ
- gRPC
- Kubernetes
- MSSQL

## Platform Service

This service is responsible for the following: 

 - CRUD operation for platforms
 - Publish a message on message bus when a new platform is created
 - Send a synchronous request to command service when a new platform is created
 - Make a gRPC call to command service when a new platform is created

Platform Json Object Representation: 

```json
	{
		"id": 3,
		"name": "Kubernetes",
		"publisher": "Cloud Native Computer Foundation",
		"cost": "Free"
	}
```

## Command Service

This service is responsible for the following: 

- CRUD operation for command
- Subscribe to RabbitMQ service to listen for platform creation