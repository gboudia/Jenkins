Feature: Create an account

A short summary of the feature

@ProfessionEtudiants
Scenario: Create an account for etudiant and chercheur
	Given User is in the register page Etu
	When User fills AdresseEtu'<AdresseEmail>' and MotDePasseEtu '<Passeword>'and ConfirmMotPasseEtu'<ConfirmPasseword>'
	And User click on CivilitéEtu'<Civilité>'
	And User fills NomEtu '<Nom>' and PrenomEtu '<Prénom>'
	And User select on PaysResidenceEtu'<PaysResidence>'
	And User fills PaysNationalitéEtu '<PaysNationalité>' and CodePostaleEtu'<CodePostal>' and villeEtu '<Ville>' TelephoneEtu '<Telephone>'
	And User clicks on ProfessionEtu "Etudiants" or PorfessionCher "Chercheurs
	And User select DomaineEtude'<DomaineEtudes>' and NiveauEtude '<NiveauEtudes>'
	And User clicks on acceptanceEtu and SubmitEtu
	Then A message of succes creationEtu is displayed

Scenario: Create an account for Institutionnel
	Given User is in the register page Inst
	When User fills AdresseInst'<AdresseEmail>' and MotDePasseInst'<Passeword>'and ConfirmMotPasseInst'<ConfirmPasseword>'
	And User click on civilitéInst '<Civilité>'
	And User fills NomInst '<Nom>' and PrenomInst '<Prenom>'
	And User select on PaysResidenceInst '<PaysResidence>'
	And User fills PaysNationalitéInst '<PaysNationalité>' and CodePostaleInst'<CodePostal>' and villeInst '<Ville>' TelephoneInst '<Telephone>'
	And User clicks on ProfessionInst "institution"
	And User fills Fonction '<Fonction>'
	And User select TypeOrganisme '<TypeOrganisme>'
	And User fillss NomOrganisme '<NomOrganisme>'
	And User clicks on acceptanceInst and SubmitInst
	Then A message of succes creationInst is displayed


