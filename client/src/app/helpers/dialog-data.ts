export enum DialogType {
    Add,
    Update,
    Build,
}

export interface DialogData<T> {
    data: T;
    title: string;
    dialogType: DialogType;
    selectedAction: string;
}