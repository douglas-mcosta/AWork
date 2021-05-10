import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: "phonetype",
})
export class PhoneTypePipe implements PipeTransform {

  transform(type: number) {
    let phoneType = "";
    if (type === 0) phoneType = "Celular";
    else phoneType = "Residencial";

    return phoneType;
  }
}
