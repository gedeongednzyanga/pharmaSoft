USE [PHARMACIE_SOFT]
GO
/****** Object:  Table [dbo].[agent]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[agent](
	[idagent] [int] NOT NULL,
	[noms] [varchar](100) NULL,
	[adresse] [varchar](100) NULL,
	[contact] [varchar](100) NULL,
	[pseudo] [varchar](50) NULL,
	[pass_word] [varchar](50) NULL,
	[niveau_acces] [varchar](10) NULL,
	[sexe] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[idagent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[approvisionnement]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[approvisionnement](
	[idapprov] [int] NOT NULL,
	[dateapprov] [datetime] NOT NULL DEFAULT (getdate()),
	[user_session] [varchar](100) NULL,
	[refourni] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idapprov] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[categorie]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categorie](
	[idcat] [int] NOT NULL,
	[designationcat] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idcat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detail_approv]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detail_approv](
	[iddetailapprov] [int] NOT NULL,
	[quantite] [int] NOT NULL DEFAULT ((0)),
	[pua] [float] NOT NULL DEFAULT ((0.0)),
	[datefabric] [date] NULL,
	[dateexpir] [date] NULL,
	[refprod] [int] NULL,
	[refapprov] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[iddetailapprov] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detail_sortie_facture]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detail_sortie_facture](
	[iddetail] [int] NOT NULL,
	[quantite] [int] NOT NULL DEFAULT ((0)),
	[pu] [float] NULL,
	[date_sortie] [datetime] NULL DEFAULT (getdate()),
	[refproduit] [int] NULL,
	[ref_entete] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[iddetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detail_sortie_service]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detail_sortie_service](
	[iddetail] [int] NOT NULL,
	[quantite] [int] NOT NULL,
	[pu] [float] NULL,
	[date_sortie] [datetime] NOT NULL,
	[refproduit] [int] NULL,
	[refentete] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[iddetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[entete_sortie_facture]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[entete_sortie_facture](
	[identete] [int] NOT NULL,
	[user_session] [varchar](50) NULL,
	[refmalade] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[identete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[entete_sortie_service]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[entete_sortie_service](
	[identete] [int] NOT NULL,
	[user_session] [varchar](100) NULL,
	[refservice] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[identete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fournisseur]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fournisseur](
	[idfourni] [int] NOT NULL,
	[nomsf] [varchar](100) NULL,
	[adresse] [varchar](150) NULL,
	[contact] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idfourni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[malade]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[malade](
	[idmalade] [int] NOT NULL,
	[noms] [varchar](100) NULL,
	[numordonance] [varchar](50) NULL,
	[maladie] [varchar](50) NULL,
	[sexe] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[idmalade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pharmacie]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pharmacie](
	[id] [int] NOT NULL,
	[noms] [varchar](300) NULL,
	[adresse] [varchar](500) NULL,
	[telephone] [varchar](20) NULL,
	[mail] [varchar](100) NULL,
	[logo] [image] NULL,
	[siteweb] [varchar](100) NULL,
	[boitepostal] [varchar](50) NULL,
	[rccm] [varchar](50) NULL,
	[idnat] [varchar](20) NULL,
	[Numimpot] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[produit]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[produit](
	[idproduit] [int] NOT NULL,
	[designationprod] [varchar](100) NULL,
	[dosage] [varchar](50) NULL,
	[forme] [varchar](50) NULL,
	[quatitestock] [int] NOT NULL DEFAULT ((0)),
	[refcategorie] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idproduit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_service]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_service](
	[idservice] [int] NOT NULL,
	[designation] [varchar](50) NULL,
	[responsable] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idservice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Affichage_Agent]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Affichage_Agent]
AS
SELECT        idagent AS Numéro, noms AS Agent, sexe AS Sexe, adresse, contact, pseudo, pass_word AS [Mot de passe], niveau_acces AS [Niveau d'accès]
FROM            dbo.agent

GO
/****** Object:  View [dbo].[Affichage_approvisionnement]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[Affichage_approvisionnement] (Numéro, Code, Produit, Quantité, [P.U],[P.T],[Date Fabrication], [Date Expiration], 
										Fournisseur, [Date Entrée]) as select 
										b.idapprov, c.idproduit, c.designationprod, a.quantite, a.pua, (a.quantite*a.pua), a.datefabric,
										a.dateexpir, d.nomsf, b.dateapprov from detail_approv as a 
										inner join approvisionnement as b on (a.refapprov=b.idapprov)
										inner join produit as c on (a.refprod=c.idproduit)
										inner join fournisseur as d on (b.refourni=d.idfourni)

GO
/****** Object:  View [dbo].[Affichage_Categorie]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Affichage_Categorie] (Numéro, Catégorie) as select * from categorie
GO
/****** Object:  View [dbo].[Affichage_details_sortie_facture]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Affichage_details_sortie_facture] as
	SELECT d.iddetail,d.quantite,d.pu,d.date_sortie,p.idproduit,p.designationprod,p.forme,p.dosage,m.idmalade,m.noms, e.identete FROM detail_sortie_facture as d
	INNER JOIN produit AS p ON d.refproduit = p.idproduit
	INNER JOIN entete_sortie_facture as e ON d.ref_entete = e.identete
	INNER JOIN malade as m ON e.refmalade = m.idmalade
GO
/****** Object:  View [dbo].[Affichage_details_sortie_service]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Affichage_details_sortie_service] as
SELECT d.iddetail,d.quantite,d.pu,d.date_sortie,p.idproduit,p.designationprod,p.forme,p.dosage,s.idservice,s.designation,s.responsable,e.identete FROM detail_sortie_service as d
INNER JOIN produit as p ON d.refproduit = p.idproduit
INNER JOIN entete_sortie_service as e ON d.refentete = e.identete
INNER JOIN t_service as s ON e.refservice = s.idservice
GO
/****** Object:  View [dbo].[Affichage_Fournisseur]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Affichage_Fournisseur] (Numéro, Fournisseur, [Adresse complète], Contact) as select * from fournisseur
GO
/****** Object:  View [dbo].[Affichage_Malade]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Affichage_Malade]
AS
SELECT        idmalade AS Numéro, noms AS Malade, sexe AS Sexe, numordonance AS [Ordonance Numéro], maladie
FROM            dbo.malade

GO
/****** Object:  View [dbo].[Affichage_Produit]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Affichage_Produit] (Numéro, Produit,Catégorie, Dosage, Forme,[Quantité en Stock])
			as select a.idproduit, a.designationprod, b.designationcat, a.dosage, a.forme, a.quatitestock
			from produit as a inner join categorie as b on a.refcategorie=b.idcat
GO
/****** Object:  View [dbo].[Affichage_Service]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Affichage_Service] (Numéro, [Service], Responsable) as select * from t_service
GO
ALTER TABLE [dbo].[detail_sortie_service] ADD  DEFAULT ((0)) FOR [quantite]
GO
ALTER TABLE [dbo].[detail_sortie_service] ADD  DEFAULT ((0.0)) FOR [date_sortie]
GO
ALTER TABLE [dbo].[approvisionnement]  WITH CHECK ADD FOREIGN KEY([refourni])
REFERENCES [dbo].[fournisseur] ([idfourni])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detail_approv]  WITH CHECK ADD FOREIGN KEY([refapprov])
REFERENCES [dbo].[approvisionnement] ([idapprov])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detail_approv]  WITH CHECK ADD FOREIGN KEY([refprod])
REFERENCES [dbo].[produit] ([idproduit])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detail_sortie_facture]  WITH CHECK ADD FOREIGN KEY([ref_entete])
REFERENCES [dbo].[entete_sortie_facture] ([identete])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detail_sortie_facture]  WITH CHECK ADD FOREIGN KEY([refproduit])
REFERENCES [dbo].[produit] ([idproduit])
GO
ALTER TABLE [dbo].[detail_sortie_service]  WITH CHECK ADD FOREIGN KEY([refentete])
REFERENCES [dbo].[entete_sortie_service] ([identete])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detail_sortie_service]  WITH CHECK ADD FOREIGN KEY([refproduit])
REFERENCES [dbo].[produit] ([idproduit])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[entete_sortie_facture]  WITH CHECK ADD FOREIGN KEY([refmalade])
REFERENCES [dbo].[malade] ([idmalade])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[entete_sortie_service]  WITH CHECK ADD FOREIGN KEY([refservice])
REFERENCES [dbo].[t_service] ([idservice])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[produit]  WITH CHECK ADD FOREIGN KEY([refcategorie])
REFERENCES [dbo].[categorie] ([idcat])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  StoredProcedure [dbo].[DELETE_AGENT]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_AGENT]
(
	@id int
)
as
BEGIN
	DELETE FROM agent WHERE idagent=@id
END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_APPROVISIONNEMENT]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_APPROVISIONNEMENT]
	(
	@id int
	)
	as
	BEGIN
		DELETE FROM approvisionnement WHERE idapprov=@id
	END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_CATEGORIE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_CATEGORIE]
(
	@id int
)
as
BEGIN
	DELETE FROM categorie WHERE idcat=@id
END

GO
/****** Object:  StoredProcedure [dbo].[DELETE_DETAIL_APPROV]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_DETAIL_APPROV]
	(
	@id int
	)
	as
	BEGIN
		DELETE FROM detail_approv WHERE iddetailapprov=@id
	END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_DETAIL_SORTIE_FACTURE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROC [dbo].[DELETE_DETAIL_SORTIE_FACTURE]
	(
		@id int
	)
	as
	BEGIN
		DELETE FROM detail_sortie_facture WHERE iddetail=@id
	END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_DETAIL_SORTIE_SERVICE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_DETAIL_SORTIE_SERVICE]
(
	@id int
)
AS
BEGIN
	DELETE FROM detail_sortie_service WHERE iddetail=@id
END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_ENTETE_SORTIE_FACTURE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_ENTETE_SORTIE_FACTURE]
(
	@id int
)
as
BEGIN
	DELETE FROM entete_sortie_facture WHERE identete=@id
END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_ENTETE_SORTIE_SERVICE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_ENTETE_SORTIE_SERVICE]
(
	@id int
)
as
BEGIN
	DELETE FROM entete_sortie_service WHERE identete=@id
END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_FOURNISSEUR]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_FOURNISSEUR]
(
	@id int
)
as
BEGIN
	DELETE FROM fournisseur WHERE idfourni=@id
END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_MALADE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_MALADE]
(
	@id int
)
as
BEGIN
	DELETE FROM malade WHERE idmalade=@id
END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_PHARMACIE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_PHARMACIE]
(
	@id int
)
AS
BEGIN
	DELETE FROM Pharmacie WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_PRODUIT]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_PRODUIT]
(
	@id int
)
as
BEGIN
	DELETE FROM produit WHERE idproduit=@id 
END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_SERVICE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DELETE_SERVICE]
(
	@id int
)
as
BEGIN
	DELETE FROM t_service WHERE idservice=@id
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_AGENT]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_AGENT](
	@id int,
	@noms varchar(100),
	@adresse varchar(100),
	@contact varchar (100),
	@pseudo varchar (50),
	@password varchar (50),
	@nivau varchar (10),
	@sexe varchar
) as begin 
	if @id in (select idagent from agent)
		begin
			update agent set noms=@noms, adresse=@adresse, contact=@contact, pseudo=@pseudo,
							 pass_word=@password, niveau_acces=@nivau, sexe=@sexe where idagent=@id
		end
	else
		begin
			insert into agent values (@id, @noms, @adresse, @contact, @pseudo, @password, @nivau, @sexe)
		end
	end
GO
/****** Object:  StoredProcedure [dbo].[INSERT_APPROVISIONNEMENT]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_APPROVISIONNEMENT](
	@id int,
	@user varchar(100),
	@ref_fourni int
	
)as begin 
	if @id in (select idapprov from approvisionnement)
		begin
			update approvisionnement set refourni=@ref_fourni where idapprov=@id
			
		end
	else 
		begin
			insert into approvisionnement values (@id, GETDATE(), @user, @ref_fourni)
			
		end
	end
GO
/****** Object:  StoredProcedure [dbo].[INSERT_CATEGORIE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[INSERT_CATEGORIE](
	@id int,
	@designation varchar (100)
) as begin
	if @id in (select idcat from categorie)
		begin
			update categorie set designationcat=@designation where idcat=@id
		end
	else
		begin
			insert into categorie values (@id, @designation)
		end
	end

GO
/****** Object:  StoredProcedure [dbo].[INSERT_DETAIL_APPROV]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERT_DETAIL_APPROV]
	(
	@id int,
	@ref_fourni int,
	@quantite int,
	@pua float,
	@datefabric date,
	@date_expir date,
	@refprod int,
	@refapprov int
	)
	as
	BEGIN
		if @id in (select iddetailapprov from detail_approv)
			begin
				update detail_approv set quantite=@quantite, pua=@pua, datefabric=@datefabric,
									 dateexpir=@date_expir, refprod=@refprod, refapprov=@refapprov where iddetailapprov=@id
			end
		else
			insert into detail_approv values (@id, @quantite, @pua, @datefabric, @date_expir, @refprod, @refapprov)
			update produit set quatitestock=quatitestock+@quantite where idproduit=@refprod
	END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_DETAIL_SORTIE_FACTURE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROC [dbo].[INSERT_DETAIL_SORTIE_FACTURE]
	(
		@id int,
		@quantite int,
		@pu float,
		@refprod int,
		@refentete int
	)
	as
	BEGIN  
		declare @enstock int = (SELECT quatitestock FROM produit WHERE idproduit=@refprod)
		if @id in (select iddetail from detail_sortie_facture)
			begin
				declare @qte int  = (SELECT quantite from detail_sortie_facture WHERE iddetail=@id);
				update produit set quatitestock=quatitestock+@qte where idproduit=@refprod

				update detail_sortie_facture set quantite=@quantite, pu=@pu, refproduit=@refprod, ref_entete=@refentete WHERE iddetail=@id
				update produit set quatitestock=quatitestock-@quantite where idproduit=@refprod
			end
		else if(@quantite<=@enstock and @quantite != 0)
			begin
				
				insert into detail_sortie_facture values (@id, @quantite, @pu, GETDATE(), @refprod, @refentete)
				update produit set quatitestock=quatitestock-@quantite where idproduit=@refprod
			end
	END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_DETAIL_SORTIE_SERVICE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERT_DETAIL_SORTIE_SERVICE]
(
	@id int,
	@quantite int,
	@pu float,
	@refprod int,
	@refentete int
)
AS
BEGIN
	if @id in (select iddetail from detail_sortie_service)
		begin 
			
			update detail_sortie_service set quantite=@quantite, pu=@pu, refproduit=@refprod where iddetail=@id
		end
	else
		begin
			
			insert into detail_sortie_service values (@id, @quantite, @pu, GETDATE(), @refprod, @refentete)
			update produit set quatitestock=quatitestock-@quantite where idproduit=@refprod
		end
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_ENTETE_SORTIE_FACTURE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERT_ENTETE_SORTIE_FACTURE]
(
	@id int,
	@user varchar(100),
	@refmaladie int	
)
as
BEGIN
	if @id in (SELECT identete from entete_sortie_facture)
		begin
			update entete_sortie_facture set user_session=@user,refmalade=@refmaladie
		end
	else
		insert into entete_sortie_facture values (@id,@user,@refmaladie)
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_ENTETE_SORTIE_SERVICE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERT_ENTETE_SORTIE_SERVICE]
(
	@id int,
	@user varchar(100),
	@refservice int	
)
as
BEGIN
	if @id in (SELECT identete from entete_sortie_service)
		begin
			update entete_sortie_service set user_session=@user,refservice=@refservice
		end
	else
		insert into entete_sortie_service values (@id,@user,@refservice)
END


GO
/****** Object:  StoredProcedure [dbo].[INSERT_FOURNISSEUR]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[INSERT_FOURNISSEUR](
	@id int,
	@noms varchar (100),
	@adresse varchar (150),
	@contact varchar (100)
) as begin
	if @id in (select idfourni from fournisseur)
		begin
			update fournisseur set nomsf=@noms, adresse=@adresse, contact=@contact where idfourni=@id
		end
	else
		begin
			insert into fournisseur values (@id, @noms, @adresse, @contact)
		end
	end

GO
/****** Object:  StoredProcedure [dbo].[INSERT_MALADE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_MALADE](
	@id int,
	@noms varchar (100), 
	@numero_ordo varchar(100),
	@maladie varchar (50), 
	@sexe varchar	
) as begin 
	if @id in (select idmalade from malade)
		begin
			update malade set noms=@noms, numordonance=@numero_ordo, maladie=@maladie, sexe=@sexe where idmalade=@id
		end
	else
		begin
			insert into malade values (@id, @noms, @numero_ordo, @maladie, @sexe)
		end
	end

GO
/****** Object:  StoredProcedure [dbo].[INSERT_PHARMACIE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERT_PHARMACIE]
(
	@id int,
	@noms varchar(300),
	@adresse varchar(500),
	@telephone varchar(20),
	@mail varchar(100),
	@logo image,
	@siteweb varchar(100),
	@boitepostal varchar(50),
	@rccm varchar(50),
	@idnat varchar(20),
	@Numimpot varchar(20)
)
AS
BEGIN
	if @id in (SELECT id FROM Pharmacie)
		BEGIN
			UPDATE Pharmacie SET noms=@noms,adresse=@adresse,telephone=@telephone,mail=@mail,logo=@logo,siteweb=@siteweb,boitepostal=@boitepostal,rccm=@rccm,idnat=@idnat,Numimpot=@Numimpot WHERE id=@id
		END
	ELSE
		BEGIN
			INSERT INTO Pharmacie VALUES (@id,@noms,@adresse,@telephone,@mail,@logo,@siteweb,@boitepostal,@rccm,@idnat,@Numimpot)
		END
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_PRODUIT]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_PRODUIT](
	@id int,
	@designation varchar(50),
	@dosage varchar(50),
	@forme varchar(50),
	@refcategorie int
) as begin
		if @id in (select idproduit from produit)
			begin
				update produit set designationprod=@designation, dosage=@dosage, forme=@forme, refcategorie=@refcategorie
									where idproduit=@id
			end
		else
			begin
				insert into produit values(@id, @designation, @dosage, @forme, 0, @refcategorie)
			end
		end

GO
/****** Object:  StoredProcedure [dbo].[INSERT_SERVICE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[INSERT_SERVICE](
	@id int, 
	@designation varchar(50),
	@responsable varchar(100)
)as begin
	if @id in (select idservice from t_service)
		begin
			update t_service set designation=@designation, responsable=@responsable where idservice=@id
		end
	else
		begin
			insert into t_service values (@id, @designation, @responsable)
		end
	end

GO
/****** Object:  StoredProcedure [dbo].[INSERT_SORTIE_MALADE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_SORTIE_MALADE] (
	@id int,
	@user varchar(50),
	@refmalade int,
	@quantite int,
	@pu float,
	@datesortie datetime,
	@refprod int
)as begin
	if @id in (select identete from entete_sortie_facture)
		begin
			update entete_sortie_facture set refmalade=@refmalade where identete=@id
			update detail_sortie_facture set quantite=@quantite, pu=@pu, refproduit=@refprod
		end
	else
		begin
			insert into entete_sortie_facture values (@id, @user, @refmalade)
			insert into detail_sortie_facture values (@id, @quantite, @pu, @datesortie, @refprod, @id)
			update produit set quatitestock=quatitestock-@quantite where idproduit=@refprod
		end
	end

GO
/****** Object:  StoredProcedure [dbo].[INSERT_SORTIE_SERVICE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERT_SORTIE_SERVICE](
	@id int,
	@user varchar(100),
	@refservice int,
	@quantite int,
	@pu float,
	@datesortie datetime,
	@refprod int
)as begin
	if @id in (select identete from entete_sortie_service)
		begin 
			update entete_sortie_service set refservice=@refservice where identete=@id
			update detail_sortie_service set quantite=@quantite, pu=@pu, refproduit=@refprod where iddetail=@id
		end
	else
		begin
			insert into entete_sortie_service values (@id, @user, @refservice)
			insert into detail_sortie_service values (@id, @quantite, @pu, @datesortie, @refprod, @refservice)
			update produit set quatitestock=quatitestock-@quantite where idproduit=@refprod
		end
	end

GO
/****** Object:  StoredProcedure [dbo].[SELECT_AGENT]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SELECT_AGENT]
as
	begin
		select Numéro,Agent,Sexe,adresse,contact,pseudo,[Niveau d'accès] from Affichage_Agent
	end
GO
/****** Object:  StoredProcedure [dbo].[SELECT_ALL_MEDICAMENTS_MALADE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECT_ALL_MEDICAMENTS_MALADE] 
	(
		@id int
	)
	as
	BEGIN
		SELECT iddetail Numéro,designationprod Produit,dosage Dosage,quantite Quantité,pu PU,(quantite*pu) as PT,noms Malade,date_sortie [Date de sortie] FROM Affichage_details_sortie_facture WHERE identete=@id
	END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_ALL_MEDICAMENTS_SERVICE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECT_ALL_MEDICAMENTS_SERVICE]
(
	@id int
)
as
BEGIN
	SELECT iddetail Numéro,designationprod Produit,dosage Dosage,quantite Quantité,pu PU,(quantite*pu) as PT,designation Service,date_sortie [Date de sortie] FROM Affichage_details_sortie_service where identete=@id
END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_APPROVISIONNEMENT]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SELECT_APPROVISIONNEMENT]
as
	begin
		select Numéro,Produit,Quantité,[P.U],[P.T],[Date Fabrication],[Date Expiration],Fournisseur,[Date Entrée] from Affichage_approvisionnement
	end
GO
/****** Object:  StoredProcedure [dbo].[SELECT_CATEGORIE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SELECT_CATEGORIE]
as
	begin
		select * from Affichage_Categorie
	end
GO
/****** Object:  StoredProcedure [dbo].[SELECT_DETAILS_SORTI_FACTURE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROC [dbo].[SELECT_DETAILS_SORTI_FACTURE]
	AS
	BEGIN
		SELECT iddetail Numéro,designationprod Produit,dosage Dosage,quantite Quantité,pu PU,(quantite*pu) as PT,noms Malade,date_sortie [Date de sortie] FROM Affichage_details_sortie_facture
	END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_DETAILS_SORTIE_SERVICE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECT_DETAILS_SORTIE_SERVICE]
AS
BEGIN

	SELECT iddetail Numéro,designationprod Produit,dosage Dosage,quantite Quantité,pu PU,(quantite*pu) as PT,designation Service,date_sortie [Date de sortie] FROM Affichage_details_sortie_service
END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_FOURNISSEUR]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SELECT_FOURNISSEUR]
as 
begin
select Numéro,Fournisseur,[Adresse complète],Contact from Affichage_Fournisseur
end
GO
/****** Object:  StoredProcedure [dbo].[SELECT_MALADE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SELECT_MALADE]
as
	begin 
		select Numéro,Malade,Sexe,[Ordonance Numéro],maladie from Affichage_Malade
	end
GO
/****** Object:  StoredProcedure [dbo].[SELECT_ONE_AGENT]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECT_ONE_AGENT]
(
	@id int
)
as
BEGIN
	select Numéro,Agent,Sexe,adresse,contact,pseudo,[Niveau d'accès] from Affichage_Agent WHERE Numéro=@id
END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_ONE_PRODUIT]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECT_ONE_PRODUIT]
(
@id int
)
as 
BEGIN
	select Numéro,Produit,Catégorie,Dosage,Forme,[Quantité en Stock] from Affichage_Produit WHERE Numéro=@id
END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_ONE_PRODUIT_DETAILS]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECT_ONE_PRODUIT_DETAILS]
(
	@id int
)
as
BEGIN
	select Numéro,Produit,Quantité,[P.U],[P.T],[Date Fabrication],[Date Expiration],Fournisseur,[Date Entrée] from Affichage_approvisionnement WHERE Code = @id
END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_ONE_PRODUIT_SORTIE_DETAILS]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECT_ONE_PRODUIT_SORTIE_DETAILS]
(
	@produit varchar(100)
)
as
BEGIN
	SELECT iddetail Numéro,designationprod Produit,dosage Dosage,quantite Quantité,pu PU,(quantite*pu) as PT,noms Malade,date_sortie [Date de sortie] FROM Affichage_details_sortie_facture WHERE designationprod=@produit
END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_PRODUIT]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SELECT_PRODUIT]
as 
	begin
		select Numéro,Produit,Catégorie,Dosage,Forme,[Quantité en Stock] from Affichage_Produit
	end
GO
/****** Object:  StoredProcedure [dbo].[SELECT_SERVICE]    Script Date: 31/07/2019 15:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SELECT_SERVICE]
as
	begin
		select Numéro,Service,Responsable from Affichage_Service
	end
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "agent"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 200
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Affichage_Agent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Affichage_Agent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "malade"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 162
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Affichage_Malade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Affichage_Malade'
GO
