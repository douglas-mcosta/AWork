export interface JobTitle {
    id: string
    jobTitleId: string | null;
    name: string;
    hidden: boolean;
    jobTitleParent: JobTitle;
    jobTitleChild: JobTitle[];
}