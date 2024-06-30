-- Add User
CREATE PROCEDURE AddUser
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(15),
    @Address NVARCHAR(200),
    @State NVARCHAR(50),
    @City NVARCHAR(50)
AS
BEGIN
    INSERT INTO Users (Name, Email, Phone, Address, State, City)
    VALUES (@Name, @Email, @Phone, @Address, @State, @City)
END
GO

-- Update User
CREATE PROCEDURE EditUser
    @Id INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(15),
    @Address NVARCHAR(200),
    @State NVARCHAR(50),
    @City NVARCHAR(50)
AS
BEGIN
    UPDATE Users
    SET Name = @Name,
        Email = @Email,
        Phone = @Phone,
        Address = @Address,
        State = @State,
        City = @City
    WHERE Id = @Id
END
GO

-- Delete User
CREATE PROCEDURE DeleteUser
    @Id INT
AS
BEGIN
    DELETE FROM Users
    WHERE Id = @Id
END
GO
