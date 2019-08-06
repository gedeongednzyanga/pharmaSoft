---------------Ajout des champs dans Agent-----------------------
ALTER TABLE agent
add email varchar(30), fonction varchar(30), photo image
--------------Modification view affichage agents------------------
GO
ALTER VIEW [dbo].[Affichage_Agent]
AS
SELECT        idagent AS Numéro, noms AS Agent, sexe AS Sexe, adresse, contact, email, fonction, pseudo, pass_word AS [Mot de passe], niveau_acces AS [Niveau d'accès], Photo
FROM            dbo.agent

GO

-------------Modification Procédure d'affichage Agent---------------------------
GO
ALTER proc [dbo].[SELECT_AGENT]
as
	begin
		select Numéro,Agent,Sexe,adresse,contact,email,fonction,pseudo,[Niveau d'accès], Photo from Affichage_Agent
	end
------------Modification procédure d'insertion agent-----------------------------
Go
ALTER proc [dbo].[INSERT_AGENT](
	@id int,
	@noms varchar(100),
	@adresse varchar(100),
	@contact varchar (100),
	@pseudo varchar (50),
	@password varchar (50),
	@nivau varchar (10),
	@sexe varchar,
	@email varchar(30),
	@fonction varchar(30),
	@photo image
) as begin 
	if @id in (select idagent from agent)
		begin
			update agent set noms=@noms, adresse=@adresse, contact=@contact, pseudo=@pseudo,
							 pass_word=@password, niveau_acces=@nivau, sexe=@sexe, email=@email,fonction=@fonction,photo=@photo where idagent=@id
		end
	else
		begin
			insert into agent values (@id, @noms, @adresse, @contact, @pseudo, @password, @nivau, @sexe,@email,@fonction,@photo)
		end
	end

