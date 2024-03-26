/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists (SELECT * FROM [dbo].[Users])
    begin 
        insert into [dbo].[Users]([Name], [eMail], [Password])
        values ('Mati', 'mail', 'pass'),
               ('Pablo', 'mail', 'pass'),
               ('Gabi', 'mail', 'pass');
    end

    if not exists (SELECT * FROM [dbo].[Artists])
    begin 
        insert into [dbo].[Artists]([Name])
        values ('Sonata Arctica'),
               ('Christopher Tim'),
               ('Pink Floyd');
    end

    if not exists (SELECT * FROM [dbo].[Tracks])

    begin 
        insert into [dbo].[Tracks]([Name], [Link], [UserId], [ArtistId])
        values('Tallulah', 'link', 1, 1), 
              ('Broken', 'link', 1, 1), 
              ('Shy', 'link', 1, 1), 
              ('Love', 'link', 1, 1), 
              ('Baba Yetu', 'link', 2, 2), 
              ('Mado Kara Mieru', 'link', 2, 2), 
              ('Civilizations V', 'link', 2, 2),
              ('The Wall', 'link', 3, 3),
              ('Run Like Hell', 'link', 3, 3),
              ('High Hopes', 'link', 3, 3);
    end

    
              