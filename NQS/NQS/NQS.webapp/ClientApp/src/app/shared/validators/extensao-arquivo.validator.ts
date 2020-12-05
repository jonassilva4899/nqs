import { ValidatorFn, ValidationErrors } from '@angular/forms';

export const extensaoArquivoValidator: any = (extensions: Array<string>): ValidatorFn => {
    return (control: any): ValidationErrors | null => {
        const value: FileList = control.value && control.value.length ? control.value : null;
        const valueAsArray: File[] = value ? Array.from(value) : [];
        const filesError = [];

        if (valueAsArray.length) {
            valueAsArray.map((file: File) => {
                let fileName: any;

                if (file && file.name) {
                    fileName = file.name.split('.');
                } else {
                    fileName = [];
                }

                const ext = `.${fileName[fileName.length - 1]}`.toLowerCase();
                filesError.push(extensions.includes(ext));
            });

            if (filesError.some(error => !error)) {
                const error = {
                    invalid: true,
                    message: 'Arquivo inválido',
                };

                if (valueAsArray.length > 1) {
                    error.message = 'Um ou mais arquivos inválidos';
                }

                return error;
            }
        }

        return null;
    };
};
