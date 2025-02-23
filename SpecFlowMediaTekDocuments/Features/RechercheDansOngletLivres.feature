Feature: RechercheDansOngletLivres
	Recherche dans l'onglet "livres" d'un livre avec son titre.

@mytag
Scenario: Recherche par titre de livre
	Given je saisis le titre "Une part de Ciel"
	Then la liste ne contient plus qu'un seul livre, et son titre est "Une part de Ciel"