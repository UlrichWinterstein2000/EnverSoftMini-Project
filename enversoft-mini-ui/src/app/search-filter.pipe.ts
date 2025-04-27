import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchFilter',
  standalone: true,
})
export class SearchFilterPipe implements PipeTransform {
  transform(items: any[], searchText: string): any[] {
    if (!items || !searchText) {
      return items;
    }
    return items.filter(item =>
      item.companyCode.toLowerCase().includes(searchText.toLowerCase()) ||
      item.companyName.toLowerCase().includes(searchText.toLowerCase()) ||
      item.telephoneNumber.toLowerCase().includes(searchText.toLowerCase())
    );
  }
}
