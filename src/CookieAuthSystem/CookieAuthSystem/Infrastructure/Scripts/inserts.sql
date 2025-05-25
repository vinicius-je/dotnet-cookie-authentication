-- Insert Roles if they don't exist
INSERT INTO Roles (Id, Name)
SELECT lower(hex(randomblob(16))), 'Admin'
WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE Name = 'Admin');

INSERT INTO Roles (Id, Name)
SELECT lower(hex(randomblob(16))), 'User'
WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE Name = 'User');

INSERT INTO Roles (Id, Name)
SELECT lower(hex(randomblob(16))), 'Manager'
WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE Name = 'Manager');

-- Insert Users if they don't exist
INSERT INTO Users (Id, Name, Email, Password)
SELECT lower(hex(randomblob(16))), 'Alice Smith', 'alice@example.com', 'hashedpassword123'
WHERE NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'alice@example.com');

INSERT INTO Users (Id, Name, Email, Password)
SELECT lower(hex(randomblob(16))), 'Bob Johnson', 'bob@example.com', 'hashedpassword456'
WHERE NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'bob@example.com');

-- Assign Roles to Users if not already assigned
INSERT INTO UserRoles (UserId, RoleId)
SELECT u.Id, r.Id
FROM Users u, Roles r
WHERE u.Email = 'alice@example.com' AND r.Name = 'Admin'
AND NOT EXISTS (
    SELECT 1 FROM UserRoles ur
    WHERE ur.UserId = u.Id AND ur.RoleId = r.Id
);

INSERT INTO UserRoles (UserId, RoleId)
SELECT u.Id, r.Id
FROM Users u, Roles r
WHERE u.Email = 'alice@example.com' AND r.Name = 'User'
AND NOT EXISTS (
    SELECT 1 FROM UserRoles ur
    WHERE ur.UserId = u.Id AND ur.RoleId = r.Id
);

INSERT INTO UserRoles (UserId, RoleId)
SELECT u.Id, r.Id
FROM Users u, Roles r
WHERE u.Email = 'bob@example.com' AND r.Name = 'User'
AND NOT EXISTS (
    SELECT 1 FROM UserRoles ur
    WHERE ur.UserId = u.Id AND ur.RoleId = r.Id
);
