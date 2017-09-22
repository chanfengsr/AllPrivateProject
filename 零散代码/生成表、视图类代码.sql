/*
SELECT ColName = syscolumns.name,
       DataType = systypes.name,
       [Length] = syscolumns.[length],
       [Description] = CAST(ISNULL( sys.extended_properties.[value],'') AS NVARCHAR(200)),
       [Default] = ISNULL( syscomments.[text],''),
       Nullable = syscolumns.isnullable,
       NetType = CASE 
                      WHEN systypes.name IN ('bit') THEN 'Boolean'
                      WHEN systypes.name IN ('tinyint') THEN 'Byte'
                      WHEN systypes.name IN ('binary','image','timestamp','varbinary') THEN 'Byte[]'
                      WHEN systypes.name IN ('date','datetime','datetime2','smalldatetime') THEN 'DateTime'
                      WHEN systypes.name IN ('datetimeoffset') THEN 'DateTimeOffset'
                      WHEN systypes.name IN ('decimal','money','numeric','smallmoney') THEN 'Decimal'
                      WHEN systypes.name IN ('float') THEN 'Double'
                      WHEN systypes.name IN ('uniqueidentifier') THEN 'Guid'
                      WHEN systypes.name IN ('smallint') THEN 'Int16'
                      WHEN systypes.name IN ('int') THEN 'Int32'
                      WHEN systypes.name IN ('bigint') THEN 'Int64'
                      WHEN systypes.name IN ('sql_variant') THEN 'Object'
                      WHEN systypes.name IN ('real') THEN 'Single'
                      WHEN systypes.name IN ('geography') THEN 'SqlGeography'
                      WHEN systypes.name IN ('geometry') THEN 'SqlGeometry'
                      WHEN systypes.name IN ('hierarchyid') THEN 'SqlHierarchyId'
                      WHEN systypes.name IN ('char','nchar','ntext','nvarchar','text','varchar','xml') THEN 'String'
                      WHEN systypes.name IN ('time') THEN 'TimeSpan'
                      ELSE ''
                  END
FROM   syscolumns
INNER JOIN   systypes
  ON   syscolumns.xtype = systypes.xusertype
LEFT JOIN   sysobjects
  ON   syscolumns.id = sysobjects.id
LEFT OUTER JOIN   sys.extended_properties
  ON   (sys.extended_properties.minor_id = syscolumns.colid AND sys.extended_properties.major_id = syscolumns.id)
LEFT OUTER JOIN   syscomments
  ON   syscolumns.cdefault = syscomments.id
WHERE  syscolumns.id IN (SELECT id
                         FROM   SYSOBJECTS
                         WHERE  xtype IN ( 'U','V'))
  AND  (systypes.name <> 'sysname')
  AND  sysobjects.name = 'CustomsStandardCode'
ORDER BY
       sysobjects.name,syscolumns.Id


SELECT [name],[value] FROM sys.extended_properties WHERE major_id IN (SELECT [id] FROM sysobjects WHERE NAME = 'ct_XH_DclrStdCode') AND minor_id = 0
*/
--TestType
--ct_XH_DclrStdCode

--TestType  PurchOrd    ct_XH_DclrImptHd    ct_XH_DclrStdCode

--****************************************************************
--对象名称(Object Name):    SQL生成C# 表、视图的实体类
--
--功能描述(Description):    比通用工具生成的全
--
--参数(Parameters):         
--
--作者(Author):             王煜
--
--日期(ALTER  Date):        2013-09-16
--
--示例(Example):            
--
--修改记录(Revision History):
--  2017-9-22   加字段名称静态变量
--
--****************************************************************
SET NOCOUNT ON

DECLARE @TableName NVARCHAR(50)
SET @TableName = 'StockHead'

DECLARE @Namespace NVARCHAR(50)
SET @Namespace = 'WindowsFormsApplication1'

DECLARE @ColName        NVARCHAR(50)
DECLARE @DataType       NVARCHAR(20)
DECLARE @Length         INT
DECLARE @Description    NVARCHAR(200)
DECLARE @Default        NVARCHAR(MAX)
DECLARE @Nullable       INT
DECLARE @NetType        NVARCHAR(20)

DECLARE @DefaultVal     SQL_VARIANT
DECLARE @DefaultStr     NVARCHAR(100)
DECLARE @StrSql         NVARCHAR(MAX)
DECLARE @TableId        INT

-- 存放表列名
DECLARE @tbColName AS TABLE ([ColName] NVARCHAR(20) NOT NULL)
DECLARE @AllColNames    NVARCHAR(MAX)


SET @TableId = (SELECT [object_id] FROM sys.objects WHERE NAME = @TableName)
SET @AllColNames = ''

PRINT 'using System;'
PRINT 'using System.Collections.Generic;'
PRINT ''
PRINT 'namespace ' + @Namespace
PRINT '{'
PRINT '    /// <summary>'

--表描述
DECLARE @DesName SYSNAME
DECLARE @DesValue SQL_VARIANT
DECLARE curTabDesc CURSOR LOCAL FAST_FORWARD READ_ONLY FOR SELECT [name],[value] FROM sys.extended_properties WHERE major_id IN (SELECT [id] FROM sysobjects WHERE NAME = @TableName) AND minor_id = 0
OPEN curTabDesc
    WHILE 1 = 1
        BEGIN
            FETCH curTabDesc INTO @DesName,@DesValue
            IF @@FETCH_STATUS <> 0
                BREAK

            PRINT '    /// ' + @DesName + ' ' + CAST(@DesValue AS NVARCHAR(50))
            --PRINT @DesValue
        END
CLOSE curTabDesc
DEALLOCATE curTabDesc

PRINT '    /// </summary>'
PRINT '    [Serializable]'
PRINT '    public class ' + @TableName
PRINT '    {'
--region 私有变量及默认值
PRINT N'        #region 私有变量及默认值'
DECLARE curPrvtVar CURSOR LOCAL FAST_FORWARD READ_ONLY FOR
    SELECT ColName = syscolumns.name,
           DataType = systypes.name,
           [Length] = CASE WHEN systypes.name IN ('nchar','nvarchar') THEN syscolumns.[length] / 2 ELSE syscolumns.[length] END,
           [Description] = CAST(ISNULL( sys.extended_properties.[value],'') AS NVARCHAR(200)),
           [Default] = ISNULL( syscomments.[text],''),
           Nullable = syscolumns.isnullable,
           NetType = CASE 
                          WHEN systypes.name IN ('bit') THEN 'Boolean?'
                          WHEN systypes.name IN ('tinyint') THEN 'Byte?'
                          WHEN systypes.name IN ('binary','image','timestamp','varbinary') THEN 'Byte[]'
                          WHEN systypes.name IN ('date','datetime','datetime2','smalldatetime') THEN 'DateTime?'
                          WHEN systypes.name IN ('datetimeoffset') THEN 'DateTimeOffset?'
                          WHEN systypes.name IN ('decimal','money','numeric','smallmoney') THEN 'Decimal?'
                          WHEN systypes.name IN ('float') THEN 'Double?'
                          WHEN systypes.name IN ('uniqueidentifier') THEN 'Guid?'
                          WHEN systypes.name IN ('smallint') THEN 'Int16?'
                          WHEN systypes.name IN ('int') THEN 'Int32?'
                          WHEN systypes.name IN ('bigint') THEN 'Int64?'
                          WHEN systypes.name IN ('sql_variant') THEN 'Object'
                          WHEN systypes.name IN ('real') THEN 'Single?'
                          WHEN systypes.name IN ('geography') THEN 'SqlGeography'
                          WHEN systypes.name IN ('geometry') THEN 'SqlGeometry'
                          WHEN systypes.name IN ('hierarchyid') THEN 'SqlHierarchyId'
                          WHEN systypes.name IN ('char','nchar','ntext','nvarchar','text','varchar','xml') THEN 'String'
                          WHEN systypes.name IN ('time') THEN 'TimeSpan?'
                          ELSE ''
                      END
    FROM   syscolumns
    INNER JOIN   systypes
      ON   syscolumns.xtype = systypes.xusertype
    LEFT JOIN   sysobjects
      ON   syscolumns.id = sysobjects.id
    LEFT OUTER JOIN   sys.extended_properties
      ON   (sys.extended_properties.minor_id = syscolumns.colid AND sys.extended_properties.major_id = syscolumns.id)
    LEFT OUTER JOIN   syscomments
      ON   syscolumns.cdefault = syscomments.id
    WHERE  syscolumns.id IN (SELECT id
                             FROM   SYSOBJECTS
                             WHERE  xtype IN ( 'U','V'))
      AND  (systypes.name <> 'sysname')
      AND  sysobjects.name = @TableName
    ORDER BY syscolumns.Id
OPEN curPrvtVar
    WHILE 1 = 1
        BEGIN
            FETCH curPrvtVar INTO @ColName, @DataType, @Length, @Description, @Default, @Nullable, @NetType
            IF @@FETCH_STATUS <> 0
                BREAK
                
            SET @AllColNames = @AllColNames + '"' + @ColName + '", '
            
            INSERT @tbColName VALUES (@ColName)

            SET @DefaultStr = ''
            IF @Default > ''
                BEGIN
                    SET @StrSql = 'SELECT @DefaultVal = ' + @Default
                    EXEC sp_executesql @StrSql, N'@DefaultVal SQL_VARIANT OUT',@DefaultVal OUT
                    
                    --IF @DataType IN ('float','smallint','int','bigint','tinyint') AND @DefaultVal = 0
                    --    GOTO OUTPUTDCLR

                    IF @DataType IN ('date','datetime','datetime2','smalldatetime')
                        BEGIN
                            IF CHARINDEX('GETDATE()',UPPER(@Default)) > 0
                                SET @DefaultStr = ' = DateTime.Now'
                            ELSE IF CHARINDEX('GETUTCDATE()',UPPER(@Default)) > 0
                                SET @DefaultStr = ' = DateTime.UtcNow'
                            ELSE
                                SET @DefaultStr = ' = DateTime.Parse("' + CONVERT(NVARCHAR(50), CAST(@DefaultVal AS DATETIME), 121) + '")'
                        END
                    ELSE IF @DataType IN ('char','nchar','ntext','nvarchar','text','varchar','xml')
                        BEGIN
                            SET @DefaultStr = ' = "' + RTRIM(CAST(@DefaultVal AS NVARCHAR(MAX))) + '"'
                        END
                    ELSE IF @DataType IN ('datetimeoffset')
                        SET @DefaultStr = ' = DateTimeOffset.Parse("' + CAST(CAST(@DefaultVal AS datetimeoffset(7)) AS NVARCHAR(50)) + '")'
                    ELSE IF @DataType IN ('bit')
                        IF @DefaultVal = 0
                            SET @DefaultStr = ' = false'
                        ELSE
                            SET @DefaultStr = ' = true'
                    ELSE IF @DataType IN ('time')
                        SET @DefaultStr = ' = TimeSpan.Parse("' + CAST(CAST(@DefaultVal AS TIME(7)) AS NVARCHAR(20)) + '")'
                    ELSE IF @DataType IN ('uniqueidentifier')
                        SET @DefaultStr = ' = new Guid("' + CAST(@DefaultVal AS NVARCHAR(50)) + '")'
                    ELSE IF @DataType IN ('tinyint','smallint','int','bigint')
                        SET @DefaultStr = ' = ' + CAST(@DefaultVal AS NVARCHAR(50))
                    ELSE IF @DataType IN ('decimal','money','numeric','smallmoney')
                        IF @DefaultVal = 0
                            SET @DefaultStr = ' = (decimal?)0.0'
                        ELSE
                            SET @DefaultStr = ' = Convert.ToDecimal(' + CAST(CONVERT(NUMERIC(38,8),@DefaultVal) AS NVARCHAR(38)) + ')'
                    ELSE IF @DataType IN ('float')
                        IF @DefaultVal = 0
                            SET @DefaultStr = ' = 0.0'
                        ELSE
                            SET @DefaultStr = ' = ' + CAST(CONVERT(NUMERIC(38,8),@DefaultVal) AS NVARCHAR(38))
                    ELSE IF @DataType IN ('real')
                        IF @DefaultVal = 0
                            SET @DefaultStr = ' = 0.0'
                        ELSE
                            SET @DefaultStr = ' = Convert.ToSingle(' + CAST(CONVERT(NUMERIC(38,8),@DefaultVal) AS NVARCHAR(38)) + ')'
                END
OUTPUTDCLR:
            PRINT '        private ' + @NetType + ' _' + @ColName + @DefaultStr + ';'
        END
CLOSE curPrvtVar
DEALLOCATE curPrvtVar
PRINT N'        #endregion 私有变量及默认值'
--endregion 私有变量及默认值
PRINT ''
PRINT N'        #region 表字段名'

DECLARE curColName CURSOR LOCAL FAST_FORWARD READ_ONLY FOR SELECT [ColName] FROM @tbColName
OPEN curColName
    WHILE 1 = 1
        BEGIN
            FETCH curColName INTO @ColName
            IF @@FETCH_STATUS <> 0
                BREAK

            PRINT '        public static string ColName_' + @ColName + ' = "' + @ColName + '";'
        END
CLOSE curColName
DEALLOCATE curColName

PRINT '        public List<string> AllColNames = new List<string> {' + SUBSTRING(@AllColNames, 0, LEN(@AllColNames)) + '};'
PRINT N'        #endregion 表字段名'
PRINT ''

PRINT N'        #region 索引组'
-- 表索引组
DECLARE @IdxName     NVARCHAR(50)
DECLARE @IdxId       INT
DECLARE @IsUniq      BIT
DECLARE @IdxColName  NVARCHAR(50)
DECLARE @IdxDecCode  NVARCHAR(MAX)

DECLARE curIdx CURSOR LOCAL FAST_FORWARD READ_ONLY FOR
    SELECT [name],[index_id],[is_unique] FROM sys.indexes WHERE [object_id] = @TableId ORDER BY [index_id]
OPEN curIdx
    WHILE 1 = 1
        BEGIN
            FETCH curIdx INTO @IdxName,@IdxId,@IsUniq
            IF @@FETCH_STATUS <> 0
                BREAK

            IF @IsUniq = 1
                SET @IdxDecCode = '        public List<string> UniIdx' + @IdxName + ' = new List<string> {'
            ELSE
                SET @IdxDecCode = '        public List<string> Idx' + @IdxName + ' = new List<string> {'

            DECLARE curIdxCols CURSOR LOCAL FAST_FORWARD READ_ONLY FOR
                SELECT B.[name]
                FROM   sys.index_columns A JOIN sys.[columns] B ON A.[object_id] = B.[object_id] AND A.column_id = B.column_id
                WHERE  A.[object_id] = @TableId
                  AND  A.index_id = @IdxId
                ORDER BY A.index_column_id
            OPEN curIdxCols
                WHILE 1 = 1
                    BEGIN
                        FETCH curIdxCols INTO @IdxColName
                        IF @@FETCH_STATUS <> 0
                            BREAK

                        --判断是否是首行
                        IF SUBSTRING(@IdxDecCode, LEN(@IdxDecCode), 1) <> '{'
                            SET @IdxDecCode = @IdxDecCode +  ','

                        SET @IdxDecCode = @IdxDecCode +  '"' + @IdxColName + '"'
                    END
            CLOSE curIdxCols
            DEALLOCATE curIdxCols

            PRINT @IdxDecCode + '};'
        END
CLOSE curIdx
DEALLOCATE curIdx
PRINT N'        #endregion 索引组'
PRINT ''
PRINT N'        #region 公共属性'
DECLARE curProp CURSOR LOCAL FAST_FORWARD READ_ONLY FOR
    SELECT ColName = syscolumns.name,
           DataType = systypes.name,
           [Length] = CASE WHEN systypes.name IN ('nchar','nvarchar') THEN syscolumns.[length] / 2 ELSE syscolumns.[length] END,
           [Description] = CAST(ISNULL( sys.extended_properties.[value],'') AS NVARCHAR(200)),
           [Default] = ISNULL( syscomments.[text],''),
           Nullable = syscolumns.isnullable,
           NetType = CASE 
                          WHEN systypes.name IN ('bit') THEN 'Boolean?'
                          WHEN systypes.name IN ('tinyint') THEN 'Byte?'
                          WHEN systypes.name IN ('binary','image','timestamp','varbinary') THEN 'Byte[]'
                          WHEN systypes.name IN ('date','datetime','datetime2','smalldatetime') THEN 'DateTime?'
                          WHEN systypes.name IN ('datetimeoffset') THEN 'DateTimeOffset?'
                          WHEN systypes.name IN ('decimal','money','numeric','smallmoney') THEN 'Decimal?'
                          WHEN systypes.name IN ('float') THEN 'Double?'
                          WHEN systypes.name IN ('uniqueidentifier') THEN 'Guid?'
                          WHEN systypes.name IN ('smallint') THEN 'Int16?'
                          WHEN systypes.name IN ('int') THEN 'Int32?'
                          WHEN systypes.name IN ('bigint') THEN 'Int64?'
                          WHEN systypes.name IN ('sql_variant') THEN 'Object'
                          WHEN systypes.name IN ('real') THEN 'Single?'
                          WHEN systypes.name IN ('geography') THEN 'SqlGeography'
                          WHEN systypes.name IN ('geometry') THEN 'SqlGeometry'
                          WHEN systypes.name IN ('hierarchyid') THEN 'SqlHierarchyId'
                          WHEN systypes.name IN ('char','nchar','ntext','nvarchar','text','varchar','xml') THEN 'String'
                          WHEN systypes.name IN ('time') THEN 'TimeSpan?'
                          ELSE ''
                      END
    FROM   syscolumns
    INNER JOIN   systypes
      ON   syscolumns.xtype = systypes.xusertype
    LEFT JOIN   sysobjects
      ON   syscolumns.id = sysobjects.id
    LEFT OUTER JOIN   sys.extended_properties
      ON   (sys.extended_properties.minor_id = syscolumns.colid AND sys.extended_properties.major_id = syscolumns.id)
    LEFT OUTER JOIN   syscomments
      ON   syscolumns.cdefault = syscomments.id
    WHERE  syscolumns.id IN (SELECT id
                             FROM   SYSOBJECTS
                             WHERE  xtype IN ( 'U','V'))
      AND  (systypes.name <> 'sysname')
      AND  sysobjects.name = @TableName
    ORDER BY syscolumns.Id
OPEN curProp
    WHILE 1 = 1
        BEGIN
            FETCH curProp INTO @ColName, @DataType, @Length, @Description, @Default, @Nullable, @NetType 
            IF @@FETCH_STATUS <> 0
                BREAK

            PRINT ''
            PRINT '        /// <summary>' + @Description
            PRINT '        /// </summary>'
            PRINT '        public ' + @NetType + ' ' + @ColName
            PRINT '        {'
            PRINT '            get { return _' + @ColName + '; }'
            PRINT '            set'
            PRINT '            {'

            IF @Nullable = 0
                BEGIN
                    PRINT '                if (value == null)'
                    PRINT '                    throw new ArgumentNullException("' + @ColName + '");'
                    PRINT ''
                END

            IF (@DataType IN ('char','nchar','text','varchar') AND @Length > -1) OR (@DataType = 'nvarchar' AND @Length > 0)
                BEGIN
                    PRINT '                const int length = ' + CAST(@Length AS VARCHAR(20)) + ';'

                    IF @Nullable = 0
                        PRINT '                _' + @ColName + ' = value.Trim().Length > length ? value.Trim().Substring(0, length) : value.Trim();'
                    ELSE
                        PRINT '                _' + @ColName + ' = value == null ? null : (value.Trim().Length > length ? value.Trim().Substring(0, length) : value.Trim());'
                END
            ELSE IF @DataType IN ('binary','varbinary') AND @Length > -1
                BEGIN
                    PRINT '                const int length = ' + CAST(@Length AS VARCHAR(20)) + ';'
                    PRINT ''
                    PRINT '                if (value.Length > length)'
                    PRINT '                    throw new ArgumentOutOfRangeException("' + @ColName + '[' + CAST(@Length AS VARCHAR(10)) + ']");'
                    PRINT ''
                    PRINT '                    _' + @ColName + ' = value;'                            
                END
            ELSE
                PRINT '                _' + @ColName + ' = value;'

            PRINT '            }'
            PRINT '        }'
        END
CLOSE curProp
DEALLOCATE curProp
PRINT N'        #endregion 公共属性'
PRINT ''
PRINT N'        #region 公共方法'
PRINT N'        /// <summary>检验不可为空项；返回是否检验通过及不能为空却为空的字段名'
PRINT N'        /// </summary>'
PRINT '        public Tuple<bool, List<string>> CheckNullable()'
PRINT '        {'
PRINT '            List<string> retList = new List<string>();'
PRINT ''

SET @AllColNames = ''
DECLARE curNullable CURSOR LOCAL FAST_FORWARD READ_ONLY FOR
    SELECT ColName = syscolumns.name
    FROM   syscolumns
    LEFT JOIN   sysobjects
      ON   syscolumns.id = sysobjects.id
    INNER JOIN   systypes
      ON   syscolumns.xtype = systypes.xusertype
    WHERE  syscolumns.id IN (SELECT id
                             FROM   SYSOBJECTS
                             WHERE  xtype IN ( 'U','V'))
      AND  sysobjects.name = @TableName
      AND  systypes.name <> 'timestamp'
      AND  syscolumns.isnullable = 0
    ORDER BY syscolumns.Id
OPEN curNullable
    WHILE 1 = 1
        BEGIN
            FETCH curNullable INTO @ColName
            IF @@FETCH_STATUS <> 0
                BREAK

            SET @AllColNames = @AllColNames + ' _' + @ColName + ' != null &&'
            
            PRINT '            if (_' + @ColName + ' == null) retList.Add("' + @ColName + '");'
        END
CLOSE curNullable
DEALLOCATE curNullable

IF LEN(@AllColNames) > 0
    BEGIN
       PRINT '' 
       PRINT '            bool retBool = ' + SUBSTRING(@AllColNames, 0, LEN(@AllColNames) - 1) + ';'
    END
ELSE
    PRINT '            bool retBool = true;'

PRINT ''
PRINT '            return Tuple.Create(retBool, retList);'
PRINT '        }'
PRINT N'        #endregion 公共方法'
PRINT '    }'
PRINT '}'