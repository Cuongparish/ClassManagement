export interface Grade {
    name: string;
    percentage: number;
    isPublic: boolean; // true: công bố, false: không công bố
    isReconsiderable: boolean; // true: có thể phúc khảo, false: không thể phúc khảo
  }
  
  export interface GradeStructure {
    idLop: string;
    grades: Grade[];
  }