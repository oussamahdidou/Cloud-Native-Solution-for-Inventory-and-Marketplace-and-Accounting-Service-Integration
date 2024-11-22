# Use the official OpenJDK image as a base
FROM openjdk:21-jdk-slim

# Set the working directory in the container
WORKDIR /app

# Copy the built Spring Boot jar into the container
COPY build/libs/stockservice-0.0.1-SNAPSHOT.jar app.jar

# Expose the application's port
EXPOSE 8080

# Command to run the application
ENTRYPOINT ["java", "-jar", "app.jar"]
