export default {
    pos: {
        search: 'Rechercher',
        configuration: 'Configuration',
        language: 'Langue',
        theme: {
            name: 'Theme',
            light: 'Clair',
            dark: 'Obscur',
        },
     
    },
    resources: {
        customers: {
            name: 'Client |||| Clients',
            fields: {
                address: 'Rue',
                birthday: 'Anniversaire',
                city: 'Ville',
                commands: 'Commandes',
                first_name: 'Prénom',
                first_seen: 'Première visite',
                groups: 'Segments',
                has_newsletter: 'Abonné à la newsletter',
                has_ordered: 'A commandé',
                last_name: 'Nom',
                last_seen: 'Vu le',
                last_seen_gte: 'Vu depuis',
                latest_purchase: 'Dernier achat',
                name: 'Nom',
                total_spent: 'Dépenses',
                zipcode: 'Code postal',
            },
            tabs: {
                identity: 'Identité',
                address: 'Adresse',
                orders: 'Commandes',
                reviews: 'Commentaires',
                stats: 'Statistiques',
            },
            page: {
                delete: 'Supprimer le client',
            },
        },
        commands: {
            name: 'Commande |||| Commandes',
            fields: {
                basket: {
                    delivery: 'Frais de livraison',
                    reference: 'Référence',
                    quantity: 'Quantité',
                    sum: 'Sous-total',
                    tax_rate: 'TVA',
                    total: 'Total',
                    unit_price: 'P.U.',
                },
                customer_id: 'Client',
                date_gte: 'Passées depuis',
                date_lte: 'Passées avant',
                nb_items: 'Nb articles',
                reference: 'Référence',
                returned: 'Annulée',
                status: 'Etat',
                total_gte: 'Montant minimum',
            },
        },
        products: {
            name: 'Poster |||| Posters',
            fields: {
                category_id: 'Catégorie',
                height_gte: 'Hauteur mini',
                height_lte: 'Hauteur maxi',
                height: 'Hauteur',
                image: 'Photo',
                price: 'Prix',
                reference: 'Référence',
                stock_lte: 'Stock faible',
                stock: 'Stock',
                thumbnail: 'Aperçu',
                width_gte: 'Largeur mini',
                width_lte: 'Margeur maxi',
                width: 'Largeur',
            },
            tabs: {
                image: 'Image',
                details: 'Détails',
                description: 'Description',
                reviews: 'Commentaires',
            },
        },
        categories: {
            name: 'Catégorie |||| Catégories',
            fields: {
                name: 'Nom',
                products: 'Produits',
            },
        },
        reviews: {
            name: 'Commentaire |||| Commentaires',
            fields: {
                customer_id: 'Client',
                command_id: 'Commande',
                product_id: 'Produit',
                date_gte: 'Publié depuis',
                date_lte: 'Publié avant',
                date: 'Date',
                comment: 'Texte',
                status: 'Statut',
                rating: 'Classement',
            },
            action: {
                accept: 'Accepter',
                reject: 'Rejeter',
            },
            notification: {
                approved_success: 'Commentaire approuvé',
                approved_error: 'Erreur: Commentaire non approuvé',
                rejected_success: 'Commentaire rejeté',
                rejected_error: 'Erreur: Commentaire non rejeté',
            },
        },
        segments: {
            name: 'Segments',
            fields: {
                customers: 'Clients',
                name: 'Nom',
            },
            data: {
                compulsive: 'Compulsif',
                collector: 'Collectionneur',
                ordered_once: 'A commandé',
                regular: 'Régulier',
                returns: 'A renvoyé',
                reviewer: 'Commentateur',
            },
        },
    },
};
