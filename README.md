# Projet : Akari | Jeu d'énigme / exploration / combat

## Lore :
Akari est un jeune loup des neiges recuilli par une famille de scientifiques vivant dans une montagne 
à la suite du meurtre de ses parents par des chasseurs alpins. 

Lors de son 6ème anniversaire les scientifiques lui ont offert un médaillon aux propriétés s'avérant un peu spéciales. Après s'être endormi, Akari, dans son rêve, 
ne parvenait pas à bouger, et se voyait nettement dans un monde qui ressemblaît fortement au sien. Mais il vit surtout un visage qui lui était familier, 
celui de son frère ayant été capturé par des chasseurs.

## Mécaniques principales :

- Enregistrement séquentiel : Le joueur à la possibilité d'appuyer sur un bouton du clavier (ou de cliquer sur un truc, à voir) pour 
lancer **l'enregistrement d'une séquence de quelques secondes de mouvements**. Lorsque le joueur commence l'enregistrement, le médaillon s'allume 
(médaillon modélisé sur le collier de Akari et dans un coin de l'écran, à côté des stats). Il s'éteint à la fin du temps imparti pour l'enregistrement.

Le temps dépend de certains facteur d'amélioration acquérissable en jeu.

Cet enregistrement sera joué dans le monde des rêves d'Akari lorsqu'il s'endormira.

- Rêve d'infini : Lorsque Akari s'endort, il se retrouve dans le monde des rêves.
Seulement, dans ce monde, le joueur ne peut pas intéragir avec Akari. Si le joueur à fait un enregistrement celui-ci est joué dans le monde onirique. 
Sinon, la caméra se contente de montrer le monde onirique du loup pendant quelques secondes avant de le faire se réveiller. 

**La spécificité est que les positions du joueur entre le monde présent et le monde onirique sont synchronisées**.

- les enregistrement sont supprimés après avoir été joués dans le monde des rêves.

- Certains endroits du monde onirique sont à éviter (ce sont des "obscurus" ils apparaissent lorsque, 
dans le monde réel, akari s'endort près d'une menace potentielle (un monstre, ou quoi que ce soit d'autre)). 
Ces obscurus tuent le joueur instantanément s'il y passe. Ce qui à pour conséquence de le faire réapparaître dans le monde réel à sa position précédente.

## Monde Présent :

## Monde Onirique (Futur) :

Le monde onirique est une projection dans le futur, qui est affectée par les 
