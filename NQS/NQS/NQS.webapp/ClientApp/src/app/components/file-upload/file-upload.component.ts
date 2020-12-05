import { Component, OnInit, forwardRef, Input, ViewChild, Renderer2, ViewEncapsulation, HostListener } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [{
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => FileUploadComponent),
    multi: true
  }],
})
export class FileUploadComponent implements OnInit, ControlValueAccessor {

    @ViewChild('fileElement', {static: true}) fileElement;

    @Input() accept: string | string[];
    @Input() multiple: boolean;

    onChange;
    onTouched;

    @HostListener('blur', ['$event.target'])
    blur($event): void {
        this.onTouched();
    }

    @HostListener('change', ['$event.target'])
    change(input): void {
        const value = input.files;
        this.onChange(value);
        this.onTouched();
    }

    constructor(private renderer: Renderer2) { }

    ngOnInit(): void {
    }

    writeValue(value: FileList): void {
        // this.renderer.setProperty(this.fileElement.nativeElement, 'value', value);
    }

    registerOnChange(fn: any): void {
        this.onChange = fn;
    }

    registerOnTouched(fn: any): void {
        this.onTouched = fn;
    }

    setDisabledState?(isDisabled: boolean): void {
        const fileElement = this.fileElement.nativeElement;
        const action = isDisabled ? 'addClass' : 'removeClass';
        this.renderer[action](fileElement, 'disabled');
        this.renderer.setProperty(fileElement, 'disabled', isDisabled);
    }

    get acceptedFiles(): string {
        if (Array.isArray(this.accept)) {
            return this.accept.join(',');
        } else {
            return this.accept;
        }
    }

}
