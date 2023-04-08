--[0][2] table for reply
Create Table dbo.NoteComments
(
    Id          Int Identity(1, 1) 
                Not Null Primary Key,               -- Id
    BoardName   NVarChar(50) Null,                  -- BoardName: Notice
    BoardId     Int Not Null,                       -- BoardId(ArticleId) 
    Name        NVarChar(25) Not Null,              -- Writer
    Opinion     NVarChar(4000) Not Null,            -- Content
    PostDate    DATETIME Default(GetDate()),        -- Date
    Password    NVarChar(255) Not Null              -- Password for deleting
)
Go
