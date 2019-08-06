------------Ajout des champs TypePersonne et email-------------------
ALTER TABLE Fournisseur
ADD TypePersonne varchar(30), email varchar(30)
----------Modification view Affichage Fournisseur---------------------
GO

ALTER view [dbo].[Affichage_Fournisseur] (Numéro, Fournisseur, [Adresse complète], Contact,TypePersonne,email) as select * from fournisseur
GO
------------Modification procedure d'affichage Fournisseur-------------------
GO
ALTER proc [dbo].[SELECT_FOURNISSEUR]
as 
begin
select Numéro,Fournisseur,[Adresse complète],Contact,TypePersonne,email from Affichage_Fournisseur
end
------------Modification procedure d'insertion fournisseur----------------------
GO
ALTER proc [dbo].[INSERT_FOURNISSEUR](
	@id int,
	@noms varchar (100),
	@adresse varchar (150),
	@contact varchar (100),
	@typepersonne varchar(30),
	@email varchar(30)
) as begin
	if @id in (select idfourni from fournisseur)
		begin
			update fournisseur set nomsf=@noms, adresse=@adresse, contact=@contact, TypePersonne=@typepersonne, email=@email where idfourni=@id
		end
	else
		begin
			insert into fournisseur values (@id, @noms, @adresse, @contact, @typepersonne, @email)
		end
	end

