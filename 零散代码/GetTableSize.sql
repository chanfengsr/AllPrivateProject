--****************************************************************
--对象名称(Object Name):	GetTableSize
--
--功能描述(Description):	获得数据库中所有用户表所占用磁盘的空间
--
--参数(Parameters):		
--
--作者(Author):			王煜
--
--日期(ALTER  Date):		2008.05.28
--
--用法事例:			    
--****************************************************************

    Declare @vchrTableName varchar(50)


    If (Select Object_ID('TempDb..#Temp1')) Is Not Null
        Drop Table #Temp1
    If (Select Object_ID('TempDb..#Temp2')) Is Not Null
        Drop Table #Temp2

    Create Table #Temp1
    (
        [Name]          [nvarchar] (50)     NOT NULL ,
        [Row]           [int]               NOT NULL ,
        [Reserved]      [nvarchar] (30)     NOT NULL ,
        [Data]          [nvarchar] (30)     NOT NULL ,
        [Index_Size]    [nvarchar] (30)     NOT NULL ,
        [UnUsed]        [nvarchar] (30)     NOT NULL 
    )
    
    Create Table #Temp2
    (
        [Name]          [nvarchar] (50)     NOT NULL ,
        [Row]           [int]               NOT NULL ,
        [Reserved]      [float]             NOT NULL ,
        [Data]          [float]             NOT NULL ,
        [Index_Size]    [float]             NOT NULL ,
        [UnUsed]        [float]             NOT NULL 
    )

    Declare Cur Cursor FAST_FORWARD For Select [Name] From dbo.sysobjects Where OBJECTPROPERTY(id, N'IsUserTable') = 1
    Open Cur
    Fetch Cur Into @vchrTableName
    While @@FETCH_STATUS = 0
        Begin 
            If RTrim(@vchrTableName) > '' 
                Begin 
                    Insert Into #Temp1 Exec sp_spaceused  @vchrTableName
                End 
            	
        	Fetch Cur Into @vchrTableName
        End 
        
    Close Cur
    Deallocate Cur
    
    Update #Temp1 Set Reserved = RTrim(REPLACE(Reserved,' KB','')),
                      Data = RTrim(REPLACE(Data,' KB','')),
                      Index_Size = RTrim(REPLACE(Index_Size,' KB','')),
                      UnUsed = RTrim(REPLACE(UnUsed,' KB',''))
    
    Insert Into #Temp2 Select * From #Temp1
    
    UPDATE #Temp2 SET Reserved = Reserved / 1024,
                      Data = Data / 1024,
                      Index_Size = Index_Size / 1024,
                      UnUsed = UnUsed / 1024
                          
    Select Name,
           Row,
           Reserved AS 'Reserved(MB)',
           Data AS 'Data(MB)',
           Index_Size AS 'Index_Size(MB)',
           UnUsed AS 'UnUsed(MB)'
    From #Temp2 --WHERE Row > 0
    Order By Reserved Desc 
