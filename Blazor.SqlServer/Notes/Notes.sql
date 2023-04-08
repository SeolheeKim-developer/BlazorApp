--[0][1] Table: Notes
--[!]  Articles, Posts, Entries, Notes, Memos, (Basic+Upload+Reply)
CREATE TABLE [dbo].[Notes]
(
    Id              Int Identity(1, 1) Not Null Primary Key,    -- ID
    Email           NVarChar(100) Null,                         -- Email
    Password        NVarChar(255) Null,                         -- Password
    ReadCount       Int Default 0,                              -- Number of views
    Encoding        NVarChar(10) Not Null,                      -- Encoding(HTML/Text)
    Homepage        NVarChar(100) Null,                         -- Hoomepage
    ModifyDate      DateTime Null,                              -- Modified Date
    ModifyIp        NVarChar(15) Null,                          -- Modified IP

    --[0] 5W1H: Who, when, where, what, how, why
    [Name]          NVarChar(25) Not Null,                      -- [2][Name](Writer)
    PostDate        DateTime Default GetDate() Not Null,        -- Date 
    PostIp          NVarChar(15) Null,                          -- IP
    [Title]         NVarChar(150) Not Null,                     -- [3][Title]
    [Content]       NText Not Null,                             -- [4][Content]__NVarChar(Max) => NText__
    Category        NVarChar(20) Default('Free') Null,          -- Category => 'notice', 'free', 'document', 'picture', ...

	--[2] main columns in resource board
    FileName        NVarChar(255) Null,                         -- name of file
    FileSize        Int Default 0,                              -- file size
    DownCount       Int Default 0,                              -- the number of download 

	--[3] key columns related to a reply board
    Ref             Int Not Null,                               -- Reference (Parent post)
    Step            Int Default 0,                              -- Reply depth (level)
    RefOrder        Int Default 0,                              -- Reply order
    AnswerNum       Int Default 0,                              -- Number of replies
    ParentNum       Int Default 0,                              -- Parent post number

    CommentCount    Int Default 0,                              -- Number of comments

    -- Additional: Add necessary items
    Num             Int Null,                                   -- number
    UserId          Int Null,                                   -- user table Id
    CategoryId      Int Null Default 0,                         -- Category table Id
    BoardId         Int Null Default 0,                         -- Boards table Id
    ApplicationId    Int Null Default 0                         -- Application table Id
)
Go
