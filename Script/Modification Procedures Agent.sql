USE [PHARMACIE_SOFT]
GO
/****** Object:  StoredProcedure [dbo].[INSERT_AGENT]    Script Date: 09/08/2019 12:33:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[INSERT_AGENT](
	@id int,
	@noms varchar(100),
	@adresse varchar(100),
	@contact varchar (100),
	@pseudo varchar (50),
	@password varchar (200),
	@nivau varchar (10),
	@sexe varchar,
	@email varchar(30),
	@fonction varchar(30),
	@photo image
) as begin 
		merge INTo  agent using(values(@id ,@noms, @adresse ,@contact, @pseudo, @password, @nivau, @sexe, @email, @fonction, @photo)) AS nelsON (a,b,c,d,e,f,g,h,i,j,k) ON agent.idagent=nelsON.a
							when matched then
			    update set noms=nelsON.b, adresse=nelson.c,contact=nelson.d,pseudo=nelson.e,pass_word=hAShbytes('sha2_512',nelsON.f),niveau_acces=nelson.g,sexe=nelson.h,email=nelson.i,fonction=nelson.j,photo=nelson.k
						when not matched then

				insert  values(a,b,c,d,e,hAShbytes('sha2_512',nelsON.f),g,h,i,j,k);
	end

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[SP_Login]
(
@nom VARCHAR(50),
@pseudo VARCHAR(50),
@pass VARCHAR(200),
@niveau VARCHAR(50)
)
	AS
	BEGIN
		SELECT noms,pseudo,pass_word,niveau_acces FROM agent WHERE pseudo=@pseudo
		 AND pass_word=HASHBYTES('SHA2_512',@pass)

	END
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER TABLE agent
ADD CONSTRAINT unique_pseudo UNIQUE(pseudo)

ALTER TABLE agent
ADD CONSTRAINT unique_agent UNIQUE(noms)

SELECT * FROM agent



