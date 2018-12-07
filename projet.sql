-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le :  ven. 07 déc. 2018 à 14:39
-- Version du serveur :  10.1.37-MariaDB
-- Version de PHP :  7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `projet`
--

-- --------------------------------------------------------

--
-- Structure de la table `model_ingredient`
--

CREATE TABLE `model_ingredient` (
  `id_model_ingr` int(11) NOT NULL,
  `nom_ingr` varchar(255) NOT NULL,
  `time_to_live` int(11) NOT NULL,
  `inventory-size` int(10) NOT NULL,
  `id_mod_stock` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `model_stockage`
--

CREATE TABLE `model_stockage` (
  `id_mod_stock` int(11) NOT NULL,
  `nom` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `model_stockage`
--

INSERT INTO `model_stockage` (`id_mod_stock`, `nom`) VALUES
(0, 'frigo'),
(1, 'congélateur'),
(2, 'armoire');

-- --------------------------------------------------------

--
-- Structure de la table `stock_ingredient`
--

CREATE TABLE `stock_ingredient` (
  `id` int(11) NOT NULL,
  `quantite` int(11) NOT NULL,
  `id_model_ingr` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `model_ingredient`
--
ALTER TABLE `model_ingredient`
  ADD PRIMARY KEY (`id_model_ingr`),
  ADD KEY `model_ingredient_model_stockage_FK` (`id_mod_stock`);

--
-- Index pour la table `model_stockage`
--
ALTER TABLE `model_stockage`
  ADD PRIMARY KEY (`id_mod_stock`);

--
-- Index pour la table `stock_ingredient`
--
ALTER TABLE `stock_ingredient`
  ADD PRIMARY KEY (`id`),
  ADD KEY `stock_ingredient_model_ingredient_FK` (`id_model_ingr`);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `model_ingredient`
--
ALTER TABLE `model_ingredient`
  ADD CONSTRAINT `model_ingredient_model_stockage_FK` FOREIGN KEY (`id_mod_stock`) REFERENCES `model_stockage` (`id_mod_stock`);

--
-- Contraintes pour la table `stock_ingredient`
--
ALTER TABLE `stock_ingredient`
  ADD CONSTRAINT `stock_ingredient_model_ingredient_FK` FOREIGN KEY (`id_model_ingr`) REFERENCES `model_ingredient` (`id_model_ingr`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
