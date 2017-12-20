import DateTimeFormat = Intl.DateTimeFormat;
import {User} from './user';

export class TextPost {
  id: number;
  postAuthor: User;
  subject: string;
  description: string;
  creationTime: Date;
}
