export class TratarStringService {

    static busca(valor: string): string {
        let valorTratado = valor;

        const letrasSemAcento = ['a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U', 'n', 'N', 'c', 'C'];
        const letrasComAcento = [
            '(á|à|ã|â|ä)',
            '(Á|À|Ã|Â|Ä)',
            '(é|è|ê|ë)',
            '(É|È|Ê|Ë)',
            '(í|ì|î|ï)',
            '(Í|Ì|Î|Ï)',
            '(ó|ò|õ|ô|ö)',
            '(Ó|Ò|Õ|Ô|Ö)',
            '(ú|ù|û|ü)',
            '(Ú|Ù|Û|Ü)',
            '(ñ)',
            '(Ñ)',
            '(ç)',
            '(Ç)',
        ];

        const regex = new RegExp(letrasComAcento.join('|'), 'g');
        valorTratado = valorTratado.replace(regex, (l) => {
            const index = letrasComAcento.findIndex((acento) => acento.includes(l));
            return letrasSemAcento[index];
        });

        return valorTratado.trim().toLocaleLowerCase().replace(/(\s)|(-)/g, '');
    }

}
