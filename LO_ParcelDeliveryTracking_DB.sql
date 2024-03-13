-- Create the parcelDeliveryTracking schema
CREATE SCHEMA IF NOT EXISTS lo_parceldeliverytracking_db;

-- Use the parcelDeliveryTracking schema
USE lo_parceldeliverytracking_db;

-- Drop existing tables if they exist
DROP TABLE IF EXISTS Deliveries;
DROP TABLE IF EXISTS Personnel;
DROP TABLE IF EXISTS Parcels;
DROP TABLE IF EXISTS Receivers;
DROP TABLE IF EXISTS Senders;
DROP TABLE IF EXISTS ParcelParticipants;
DROP TABLE IF EXISTS Address;

-- Create the Address Table
CREATE TABLE Address (
    addressID INT PRIMARY KEY AUTO_INCREMENT,
    addressLine VARCHAR(50) NOT NULL,
    city VARCHAR(30) NOT NULL,
    suburb VARCHAR(30),
    postalCode VARCHAR(20) NOT NULL
);

-- Create the ParcelParticipant Table
CREATE TABLE ParcelParticipants (
    participantID INT PRIMARY KEY AUTO_INCREMENT,
    participantName VARCHAR(50) NOT NULL,
    addressID INT,
    phoneNumber VARCHAR(15) NOT NULL,
    emailAddress VARCHAR(50),
    FOREIGN KEY (addressID) REFERENCES Address(addressID)
);

CREATE TABLE Senders (
    senderID INT PRIMARY KEY AUTO_INCREMENT,
    participantID INT,
    typeOfSender VARCHAR(20),
    FOREIGN KEY (participantID) REFERENCES ParcelParticipants(participantID)
);

-- Create the Receiver Table
CREATE TABLE Receivers (
    receiverID INT PRIMARY KEY AUTO_INCREMENT,
    participantID INT,
    FOREIGN KEY (participantID) REFERENCES ParcelParticipants(participantID)
);

-- Create the Parcel Table
CREATE TABLE Parcels (
    parcelID INT PRIMARY KEY AUTO_INCREMENT,
    senderID INT,
    receiverID INT,
    weight DOUBLE(10, 2) NOT NULL,
    parcelStatus VARCHAR(20),
    deliveryDate DATETIME, 
    additionalNotes VARCHAR(255),
    FOREIGN KEY (senderID) REFERENCES Senders(senderID),
    FOREIGN KEY (receiverID) REFERENCES Receivers(receiverID)
);

-- Create the Personnel Table
CREATE TABLE Personnel (
    personnelID INT PRIMARY KEY AUTO_INCREMENT,
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    phoneNumber VARCHAR(15) NOT NULL, 
    emailAddress VARCHAR(50),
    personnelRole VARCHAR(50) NOT NULL,
    availability VARCHAR(20)
);

-- Create the Delivery Table
CREATE TABLE Deliveries (
    deliveryID INT PRIMARY KEY AUTO_INCREMENT,
    parcelID INT,
    deliveryPersonnel INT,
    deliveryStatus VARCHAR(20),
    deliveryDate DATETIME,
    FOREIGN KEY (parcelID) REFERENCES Parcels(parcelID),
    FOREIGN KEY (deliveryPersonnel) REFERENCES Personnel(personnelID)
);


######################################################
# insert 
#######################################################

-- Insert sample data into Address Table
INSERT INTO Address (addressLine, city, suburb, postalCode)
VALUES
    ('123 Main St', 'Cityville', 'Downtown', '12345'),
    ('456 Elm St', 'Townsville', 'Uptown', '54321'),
    ('789 Oak St', 'Metroville', 'Suburbia', '67890'),
    ('101 Pine St', 'Villageton', 'Ruralville', '98765'),
    ('222 Maple St', 'Cityville', 'Downtown', '24680'),
    ('333 Birch St', 'Townsville', 'Uptown', '13579');

-- Insert sample data into ParcelParticipant Table
INSERT INTO ParcelParticipants (participantName, addressID, phoneNumber, emailAddress)
VALUES
    ('John Smith', 1, '555-123-4567', 'john@example.com'),
    ('Jane Doe', 2, '555-987-6543', 'jane@example.com'),
    ('Acme Inc.', 3, '555-555-5555', 'acme@example.com'),
    ('Emily Brown', 4, '555-222-3333', 'emily@example.com'),
    ('Bob Johnson', 5, '555-444-5555', 'bob@example.com'),
    ('Sara Wilson', 6, '555-777-8888', 'sara@example.com');

-- Insert sample data into Sender Table
INSERT INTO Senders (participantID, typeOfSender)
VALUES
    (1, 'Individual'),
    (3, 'Business'),
    (5, 'Individual'),
    (6, 'Individual'),
    (2, 'Individual'),
    (4, 'Individual');

-- Insert sample data into Receiver Table
INSERT INTO Receivers (participantID)
VALUES
    (1),
    (3),
    (5),
    (6),
    (2),
    (4);

-- Insert sample data into Parcel Table
INSERT INTO Parcels (senderID, receiverID, weight, parcelStatus, deliveryDate, additionalNotes)
VALUES
    (1, 2, 5.5, 'In Transit', '2023-09-15 09:30:00', 'Fragile item'),
    (3, 4, 8.2, 'Delivered', '2023-09-10 14:15:00', 'Handle with care'),
	(5, 6, 3.1, 'On Hold', NULL, 'Customer requested delay'),
    (2, 1, 7.7, 'In Transit', '2023-09-20 11:45:00', 'Express delivery'),
    (4, 3, 6.0, 'Delivered', '2023-09-05 13:20:00', NULL),
    (6, 5, 4.5, 'In Transit', '2023-09-18 10:00:00', 'Fragile item');

-- Insert sample data into Personnel Table
INSERT INTO Personnel (firstName, lastName, phoneNumber, emailAddress, personnelRole, availability)
VALUES
    ('David', 'Johnson', '555-111-2222', 'david@example.com', 'Delivery Driver', 'On Duty'),
    ('Sarah', 'Smith', '555-333-4444', 'sarah@example.com', 'Manager', 'On Duty'),
    ('Michael', 'Brown', '555-555-6666', 'michael@example.com', 'Delivery Driver', 'Off Duty'),
    ('Linda', 'Williams', '555-777-8888', 'linda@example.com', 'Manager', 'On Duty'),
    ('Tom', 'Davis', '555-999-0000', 'tom@example.com', 'Delivery Driver', 'On Duty'),
    ('Laura', 'Anderson', '555-222-3333', 'laura@example.com', 'Delivery Driver', 'Off Duty');

-- Insert sample data into Delivery Table
INSERT INTO Deliveries (parcelID, deliveryPersonnel, deliveryStatus, deliveryDate)
VALUES
    (1, 1, 'In Progress', NULL),
    (2, 3, 'Completed', '2023-09-10 15:30:00'),
    (3, 6, 'Scheduled', NULL),
    (4, 4, 'In Progress', NULL),
    (5, 5, 'Scheduled', NULL),
    (6, 2, 'Completed', '2023-09-05 16:45:00');
