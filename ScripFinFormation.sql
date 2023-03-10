create database [GestionGym]
USE [GestionGym]
GO
/****** Object:  Table [dbo].[abonner]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[abonner](
	[id] [int] NOT NULL,
	[datedebut] [date] NULL,
	[datefin] [date] NULL,
	[idmembere] [int] NULL,
	[idabonnement] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[coach]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[coach](
	[id_coach] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](100) NULL,
	[prenom] [varchar](100) NULL,
	[numero] [varchar](10) NULL,
	[sexe] [varchar](10) NULL,
	[nom_sport] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_coach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[nom_sport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[membere]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[membere](
	[id_membere] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](100) NULL,
	[prenom] [varchar](100) NULL,
	[datenaissence] [date] NULL,
	[telephone] [varchar](10) NULL,
	[sexe] [varchar](100) NULL,
	[idsalle] [int] NULL,
 CONSTRAINT [PK_id_client] PRIMARY KEY CLUSTERED 
(
	[id_membere] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[telephone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[offrir]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[offrir](
	[id_offrire] [int] IDENTITY(1,1) NOT NULL,
	[capacity] [int] NULL,
	[numsalle] [int] NULL,
	[numsport] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_offrire] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participer]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participer](
	[id_participer] [int] IDENTITY(1,1) NOT NULL,
	[idsport] [int] NULL,
	[idmembere] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salle]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salle](
	[id_salle] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NULL,
	[nom] [varchar](100) NULL,
	[nom_salle] [varchar](100) NULL,
	[motpasse] [varchar](100) NULL,
	[Type] [varchar](50) NULL,
	[Idadmin] [varchar](50) NULL,
 CONSTRAINT [PK_id_salle] PRIMARY KEY CLUSTERED 
(
	[id_salle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sport]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sport](
	[id_sport] [int] IDENTITY(1,1) NOT NULL,
	[nom_sport] [varchar](100) NULL,
	[ctaegorie] [varchar](100) NULL,
	[idcoach] [int] NULL,
	[tarif] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_sport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[type_abonnement]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[type_abonnement](
	[id_abonnement] [int] NOT NULL,
	[duree] [int] NULL,
	[tarifabonnement] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_abonnement] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[abonner]  WITH CHECK ADD  CONSTRAINT [FK_abonner_idabonnement] FOREIGN KEY([idabonnement])
REFERENCES [dbo].[type_abonnement] ([id_abonnement])
GO
ALTER TABLE [dbo].[abonner] CHECK CONSTRAINT [FK_abonner_idabonnement]
GO
ALTER TABLE [dbo].[abonner]  WITH CHECK ADD  CONSTRAINT [FK_abonner_idmemmbere] FOREIGN KEY([idmembere])
REFERENCES [dbo].[membere] ([id_membere])
GO
ALTER TABLE [dbo].[abonner] CHECK CONSTRAINT [FK_abonner_idmemmbere]
GO
ALTER TABLE [dbo].[membere]  WITH CHECK ADD  CONSTRAINT [FK_member_idsalle] FOREIGN KEY([idsalle])
REFERENCES [dbo].[salle] ([id_salle])
GO
ALTER TABLE [dbo].[membere] CHECK CONSTRAINT [FK_member_idsalle]
GO
ALTER TABLE [dbo].[offrir]  WITH CHECK ADD  CONSTRAINT [FK_id_salle] FOREIGN KEY([numsalle])
REFERENCES [dbo].[salle] ([id_salle])
GO
ALTER TABLE [dbo].[offrir] CHECK CONSTRAINT [FK_id_salle]
GO
ALTER TABLE [dbo].[offrir]  WITH CHECK ADD  CONSTRAINT [FK_id_sport] FOREIGN KEY([numsport])
REFERENCES [dbo].[sport] ([id_sport])
GO
ALTER TABLE [dbo].[offrir] CHECK CONSTRAINT [FK_id_sport]
GO
ALTER TABLE [dbo].[participer]  WITH CHECK ADD  CONSTRAINT [FK_id_member] FOREIGN KEY([idmembere])
REFERENCES [dbo].[membere] ([id_membere])
GO
ALTER TABLE [dbo].[participer] CHECK CONSTRAINT [FK_id_member]
GO
ALTER TABLE [dbo].[participer]  WITH CHECK ADD  CONSTRAINT [FK_idsport] FOREIGN KEY([idsport])
REFERENCES [dbo].[sport] ([id_sport])
GO
ALTER TABLE [dbo].[participer] CHECK CONSTRAINT [FK_idsport]
GO
ALTER TABLE [dbo].[sport]  WITH CHECK ADD  CONSTRAINT [FK_coach_id] FOREIGN KEY([idcoach])
REFERENCES [dbo].[coach] ([id_coach])
GO
ALTER TABLE [dbo].[sport] CHECK CONSTRAINT [FK_coach_id]
GO
/****** Object:  StoredProcedure [dbo].[modifer_member]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[modifer_member](@idsport int,
								@idmember int,
								@idabonnement int,
								@datedebut date,
								@datefin date,
								@prix int)



as 
	begin
	UPDATE participer SET idsport = @idsport WHERE idmembere = @idmember;
	update abonner set datedebut = @datedebut ,datefin = @datefin where idmembere = @idmember;
	update type_abonnement set tarifabonnement = @prix ,duree = DATEDIFF(month,@datedebut,@datefin) where id_abonnement = @idabonnement;

	end
GO
/****** Object:  StoredProcedure [dbo].[N_M_P_S]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[N_M_P_S]
@name varchar(50),
@info int out
as 
	begin
	set @info = (select count(*) from sport inner join participer on id_sport = idsport where nom_sport =@name)
end
GO
/****** Object:  StoredProcedure [dbo].[spchangerMDP]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spchangerMDP] @motpasse varchar(50),@email varchar(100)
as 
begin
update salle set motpasse = @motpasse where email = @email
end
GO
/****** Object:  StoredProcedure [dbo].[spGetactivemember]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetactivemember]
as 
begin
select count(*) from membere inner join abonner on id_membere = idmembere where datefin > getdate()
end
GO
/****** Object:  StoredProcedure [dbo].[spGetaddmember]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetaddmember]
as 
begin
select count(*) from membere inner join abonner on id_membere = idmembere where datedebut = convert(varchar, getdate(), 23)
end
GO
/****** Object:  StoredProcedure [dbo].[spGetemember]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetemember]
as 
begin
select count(*) from membere 
end
GO
/****** Object:  StoredProcedure [dbo].[spGetemembers]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetemembers]
as 
begin
select count(*) from membere 
end
GO
/****** Object:  StoredProcedure [dbo].[spGetfichierRenouvell]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spGetfichierRenouvell]
as
begin
select prenom,nom,nom_sport,duree,tarif,id_sport,idabonnement,id_membere from membere inner join abonner on id_membere = idmembere 
inner join type_abonnement on idabonnement = id_abonnement
inner join participer on id_membere = participer.idmembere inner join sport on id_sport = idsport 
where datefin <= convert(varchar, getdate(), 23);
end
GO
/****** Object:  StoredProcedure [dbo].[spGetfichiersport]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetfichiersport]
as 
begin
select id_sport,nom_sport,ctaegorie,capacity from sport inner join offrir on id_sport=numsport 
end
GO
/****** Object:  StoredProcedure [dbo].[spGetinactivemember]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetinactivemember]
as 
begin
select count(*) from membere inner join abonner on id_membere = idmembere where datefin < getdate()
end
GO
/****** Object:  StoredProcedure [dbo].[spGetinfocrystalreport]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetinfocrystalreport]
as
begin
select nom,prenom,nom_sport,datefin from membere inner join abonner on abonner.idmembere = membere.id_membere inner join 
participer on participer.idmembere = membere.id_membere inner join sport on sport.id_sport = participer.idsport
where datefin > GETDATE()
end
GO
/****** Object:  StoredProcedure [dbo].[spGetmember]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetmember] @idsalle int
as
begin
	select prenom,nom,datenaissence,telephone,sexe,nom_sport,id_membere,datedebut,datefin,duree,tarifabonnement,idabonnement,id_sport  from 
	membere inner join participer on idmembere = id_membere inner join sport on idsport = id_sport inner join abonner 
	on membere.id_membere = abonner.idmembere inner join type_abonnement on idabonnement = id_abonnement where datefin > convert(varchar,getdate(),23)
	and idsalle = @idsalle
	end
GO
/****** Object:  StoredProcedure [dbo].[spGetmemberAJ] Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create procedure [dbo].[spGetmemberAJ] @idsalle int
as
begin
	select prenom,nom,datenaissence,telephone,sexe,nom_sport,id_membere,datedebut,datefin,duree,tarifabonnement,idabonnement,id_sport  from 
	membere inner join participer on idmembere = id_membere inner join sport on idsport = id_sport inner join abonner 
	on membere.id_membere = abonner.idmembere inner join type_abonnement on idabonnement = id_abonnement where datefin > convert(varchar,getdate(),23)
	and idsalle = @idsalle and datedebut = convert(varchar,getdate(),23)
	end
GO
/****** Object:  StoredProcedure [dbo].[spGetprixaujour]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetprixaujour]
as 
begin
declare @prix int = (select sum(tarifabonnement) from membere inner join abonner on id_membere = idmembere 
	inner join type_abonnement on idabonnement = id_abonnement
	inner join participer on id_membere = participer.idmembere inner join sport on id_sport = idsport 
	where datedebut = convert(varchar, getdate(), 23));
	if(@prix != 0)
		begin
			select @prix
		end
	else
	begin
		set @prix = 0
		select @prix
	end

end
GO
/****** Object:  StoredProcedure [dbo].[spGetprixchoixsport]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetprixchoixsport] @sport varchar(100)
as 
begin
select tarif from sport where nom_sport = @sport
end
GO
/****** Object:  StoredProcedure [dbo].[spGetprixparchoix]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetprixparchoix] @sport varchar(50),@datedebut date,@datefin date
as begin
declare @prix int = (select sum(tarifabonnement) from membere inner join abonner on id_membere = idmembere 
inner join type_abonnement on idabonnement = id_abonnement
inner join participer on id_membere = participer.idmembere inner join sport on id_sport = idsport 
where nom_sport = @sport and datedebut between @datedebut and @datefin)
if(@prix != 0)
	begin
		select @prix
	end
else
	begin
		set @prix = 0
		select @prix
	end
end
GO
/****** Object:  StoredProcedure [dbo].[spGetprixsport]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetprixsport] @sport varchar(50)
as begin
declare @prix int = (select sum(tarifabonnement) from membere inner join abonner on id_membere = idmembere 
inner join type_abonnement on idabonnement = id_abonnement
inner join participer on id_membere = participer.idmembere inner join sport on id_sport = idsport 
where nom_sport = @sport)
if(@prix != 0)
	begin
		select @prix
	end
else
	begin
		set @prix = 0
		select @prix
	end

end
GO
/****** Object:  StoredProcedure [dbo].[spGetprixyear]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetprixyear] @year int
as 
begin
declare @prix int = (select sum(tarifabonnement) from membere inner join abonner on id_membere = idmembere 
inner join type_abonnement on idabonnement = id_abonnement
inner join participer on id_membere = participer.idmembere inner join sport on id_sport = idsport 
where  year(datedebut) = @year  )
if(@prix != 0)
	begin
		select @prix
	end
else
	begin
		set @prix = 0
		select @prix
	end

end
GO
/****** Object:  StoredProcedure [dbo].[spGetsport]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetsport]
as 
begin
select count(*) from sport   
end
GO
/****** Object:  StoredProcedure [dbo].[spGettarifmois]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------------------LINK
alter procedure [dbo].[spGettarifmois]
as 
begin
	declare @tarif int
	set @tarif = (select sum(tarifabonnement) from membere inner join abonner on id_membere = idmembere 
	inner join type_abonnement on idabonnement = id_abonnement
	inner join participer on id_membere = participer.idmembere inner join sport on id_sport = idsport 
	where  month(datedebut) = MONTH(GETDATE())  and day(datedebut) between 1 and 31)
	if(@tarif > 0 )
		select @tarif
	else
		begin
			set @tarif = 0
			select @tarif
		end

end
GO
/****** Object:  StoredProcedure [dbo].[spmodificationtarif]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spmodificationtarif]
as 
	begin

		declare @durre int,@db date,@df date,@idab int,@tarif int,@tarifsport int
		declare updateduree cursor for select datedebut, datefin,idabonnement,tarif from membere inner join abonner on id_membere = idmembere 
		inner join type_abonnement on idabonnement = id_abonnement inner join participer on participer.idmembere = membere.id_membere
		inner join sport on sport.id_sport = participer.idsport

		
		open updateduree
			fetch updateduree into @db,@df,@idab,@tarifsport
			while @@FETCH_STATUS = 0
				begin
						if(@df >convert(varchar,getdate(),23))
							begin
							set @durre = (month(@df) - month(@db))
							set @tarif = @durre * @tarifsport;
							update type_abonnement set duree = @durre,tarifabonnement = @tarif where id_abonnement = @idab;
							fetch updateduree into @db,@df,@idab,@tarifsport
							end
						else
							begin
								set @durre = 0
								update type_abonnement set duree = @durre,tarifabonnement = 0  where id_abonnement = @idab;
								fetch updateduree into @db,@df,@idab,@tarifsport
							end
				end
		close updateduree
		deallocate updateduree
	end
GO
/****** Object:  StoredProcedure [dbo].[spRenouvelle]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter procedure [dbo].[spRenouvelle] (@idsport int,
								@idmember int,
								@idabonnement int,
								@datedebut date,
								@dure int,
								@prix int)



as 
	begin
	UPDATE participer SET idsport = @idsport WHERE idmembere = @idmember;
	update abonner set datedebut = convert(varchar,getdate(),23) ,datefin = dateadd(MONTH,@dure,@datedebut) where idmembere = @idmember;
	update type_abonnement set tarifabonnement = @prix ,duree = @dure where id_abonnement = @idabonnement;

	end
GO
/****** Object:  StoredProcedure [dbo].[supp_coach]    Script Date: 05/05/2022 20:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter procedure [dbo].[supp_coach]
@nomsport varchar(100),
@info int out
as 
	begin
	set @info = 0;
	--(select count(id_coach) from coach where nom_sport in (select nom_sport from sport where nom_sport =@nomsport))
	set @info = (select count(idmembere) from sport inner join participer on sport.id_sport = participer.idsport  inner join offrir on sport.id_sport = offrir.numsport inner join coach on coach.id_coach = idcoach where sport.nom_sport =@nomsport group by sport.nom_sport)
	if(@info != 0)
	set @info = 1
	else
	set @info = 0
	
	end
GO



GO
ALTER TABLE dbo.DocExe
DROP CONSTRAINT FK_Column_B;
GO
---------------------------------------------------
----------------------------------------------------------------------------------------
create trigger tr_delete_membere on membere  instead of delete
as
	begin
		declare @id int,@idparticiper int,@id_abonnement int
		select @id = id_membere from deleted
		select @idparticiper = id_participer from participer where idmembere = @id
		select @id_abonnement = idabonnement from abonner where idmembere = @id
		
		DELETE FROM participer WHERE id_participer = @idparticiper;
		
		DELETE FROM abonner WHERE idmembere = @id;
		DELETE FROM type_abonnement WHERE id_abonnement = @id_abonnement;
		
		DELETE FROM membere WHERE id_membere = @id;
	end

---------------------------------------------------------------------
create trigger tr_delete_sport on sport instead of delete
as 
begin 
		declare @idcoach int ,@idsport int
		select @idcoach = idcoach from deleted
		select @idsport = id_sport from deleted
			print @idcoach
			print @idsport
			delete from offrir where numsport = @idsport
			DELETE FROM sport WHERE id_sport = @idsport;
			DELETE FROM coach WHERE id_coach = @idcoach;
			
end

----------------------------------------------
create proc SPchecksport @namesport varchar(100)
as
begin
select count(*) from sport inner join participer on 
id_sport = participer.idsport where nom_sport = @namesport
end





create table historique
(
datedebut date,
datefin date,
tarif money,
dure int,
idsport int,
idsalle int
)
------------------------------------------------
create procedure [dbo].[spGettarifmoisHistorique]
as begin
	(select sum(tarif) from historique 
	where month(datedebut) = MONTH(GETDATE())  and day(datedebut) between 1 and 31)
end

CREATE procedure [dbo].[spGetprixchoixsportonlyHistorique] @sport varchar(100)
as begin
declare @idsport int = (select id_sport from sport where nom_sport = @sport)
select sum(tarif) from historique where idsport = @idsport and datefin > getdate()
end

CREATE procedure [dbo].[spGetprixparchoixmultipeHistorique] @sport varchar(50),@datedebut date,@datefin date
as begin
declare @idsport int = (select id_sport from sport where nom_sport = @sport)
declare @prix int = (select sum(tarif) from historique 
where idsport = @idsport and datedebut between @datedebut and @datefin)
if(@prix != 0)
	begin
		select @prix
	end
else
	begin
		set @prix = 0
		select @prix
	end
end

create procedure [dbo].[spGetprixyearHistorique] @year int
as begin
declare @prix int = (select sum(tarif) from historique where  year(datedebut) = @year  )
if(@prix != 0)
	begin
		select @prix
	end
else
	begin
		set @prix = 0
		select @prix
	end

end


