import {PollParticipant} from './poll-participant';

export class PollItem {
  id: number;
  pollItemText: string;
  pollItemParticipants: PollParticipant[];
}
