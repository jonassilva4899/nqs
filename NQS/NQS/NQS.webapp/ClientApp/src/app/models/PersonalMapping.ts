export class PersonalMapping {
    idTitulo: string;
    titulo: string;
    itens: PersonalMappingItem[];
}

export class PersonalMappingItem {
    idItem: string;
    nomeItem: string;
}

export class PersonalMappingPost {
    IdPessoa: string;
    Titulo: string;
    Itens: string[];
    IdResponsavel: string;
}

export class PersonalMappingPut {
    IdPessoa: string;
    IdTitulo: string;
    Titulo: string;
    Itens: PersonalMappingItemPut[];
    IdResponsavel: string;
}

export class PersonalMappingItemPut {
    IdItem: string;
    NomeItem: string;
}
