import {User} from './user';
import {PollItem} from './poll-item';

export class PollPost {
  id: number;
  postAuthor: User;
  subject: string;
  description: string;
  creationDate: Date;
  pollItems: PollItem[];
  likes: any;
}
